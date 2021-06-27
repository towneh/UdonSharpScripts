
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class FireTheWorks : UdonSharpBehaviour
{   
    public GameObject target;
    public AudioSource soundEffect;
    private float _cooldownStart;
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
		//How do I pass "cooldownStart" float value to late joiner if "cooldownActive" boolean is true?
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
	if (_cooldownStart == 0) {
	    _cooldownActive = false;
	}
	// spam delay of 15 minutes between each firework session
        else if (_currentTime - _cooldownStart <= 900000) { 
	    _cooldownActive = true;
	}
	else {
	    _cooldownActive = false;
        }
    }
	
    public void TriggerTarget()
    {
	UpdateCooldown();
	target.SetActive(true);
	soundEffect.Play();
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
