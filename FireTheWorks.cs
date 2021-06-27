
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class FireTheWorks : UdonSharpBehaviour
{   
    [Header("Target GameObject")]
    [Tooltip("This will be enabled/disabled with a cooldown")]
    public GameObject target;
    
    [Header("SFX Source")]
    [Tooltip("Audio source object to be used")]
    public AudioSource sfxSource;
    [Tooltip("Audio clip to be used")]
    public AudioClip sfxClip;
    
    [Header("Cooldown Timer")]
    [Tooltip("Set length of time in minutes for cooldown")]
    [Range(1, 30)]
    public int cooldownDelay = 5;
    
    [UdonSynced] private float _cooldownStart;
    private float _currentTime;
    private bool _cooldownActive;
    
    public override void Interact()
    {
        CheckCooldown();
	if (_cooldownActive) return;
	else {
	    SendCustomNetworkEvent(NetworkEventTarget.All, "TriggerTarget");
        }
    }
	
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (Networking.IsMaster)
	{
	    if (_cooldownActive)
	    {
	        SendCustomNetworkEvent(NetworkEventTarget.All, "SerializeData");
            }
        }
    }
	
    public void UpdateCooldown()
    {
        _cooldownStart = Networking.GetServerTimeInMilliseconds();
    }
	
    public void CheckCooldown()
    {
	_currentTime = Networking.GetServerTimeInMilliseconds();
        int _cooldownDelayMs = cooldownDelay * 60000;
	if (_cooldownStart == 0) {
	    _cooldownActive = false;
	}
	// only fire if timer has exceeded cooldown delay
        else if (_currentTime - _cooldownStart <= _cooldownDelayMs) { 
	    _cooldownActive = true;
	}
	else {
	    _cooldownActive = false;
        }
    }
	
    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }

    public void TriggerTarget()
    {
	UpdateCooldown();
	target.SetActive(true);
        PlaySFX(sfxClip);
	SendCustomEventDelayedSeconds(nameof(DisableTarget), 17.0f);
    }
	
    public void DisableTarget()
    {
	target.SetActive(false);
    }
    public void SerializeData()
    {
        RequestSerialization();
    }
}
