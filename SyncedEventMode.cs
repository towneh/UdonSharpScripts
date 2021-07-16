
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class SyncedEventMode : UdonSharpBehaviour
{
    [Header("Toggle Settings")] [Tooltip("Video Player Canvas")]
    public GameObject _videoPlayerCanvas;
    [Tooltip("Door & Collider")]
    public GameObject _staffDoor;
	
    [Header("Button Behaviour")] [Tooltip("Off Button Graphic")]
    public GameObject _gfxButtonOff;
    [Tooltip("On Button Graphic")]
    public GameObject _gfxButtonOn;
    [Tooltip("AudioSource for SFX")]
    public AudioSource _audioToggleSrc;
    [Tooltip("AudioClip for Off")]
    public AudioClip _audioDisableClip;
    [Tooltip("AudioClip for On")]
    public AudioClip _audioEnableClip;
	
    [Header("DDVR Staff")] [Tooltip("Who has access override during event mode")]
    public string[] _eventAdmins;
	
    [UdonSynced] private bool _isEventOn;
    
	private void Start() 
	{
	    _isEventOn = false;
	}
	   
        public override void Interact()
	{
	    //we only want this to work for staff
	    foreach(string _adminPlayers in _eventAdmins) {
                if (Networking.LocalPlayer.displayName == _adminPlayers) {
	            SendCustomNetworkEvent(NetworkEventTarget.All, "_ToggleTarget");
		}
	    }
	}
	
	public override void OnPlayerJoined(VRCPlayerApi player)
	{
	    if (Networking.IsMaster)
	        {
		    if (_isEventOn)
		        {
			    SendCustomNetworkEvent(NetworkEventTarget.All, "_ToggleTargetTrue");
			}
			else
			{
			    SendCustomNetworkEvent(NetworkEventTarget.All, "_ToggleTargetFalse");
			}
		}
	}
	
	public void _ToggleTarget()
	{
	    Debug.Log("d: World event mode toggle request received");
	    if (_isEventOn)
	    {
		_audioToggleSrc.PlayOneShot(_audioDisableClip);
            }
	    else
	    {
		_audioToggleSrc.PlayOneShot(_audioEnableClip);
	    }
	    _gfxButtonOff.SetActive(!_gfxButtonOff.activeSelf);
	    _gfxButtonOn.SetActive(!_gfxButtonOn.activeSelf);
	    _isEventOn = !_isEventOn;
	    //staff are immune to the gameobject toggle section
	    foreach(string _adminPlayers in _eventAdmins) {
                if (Networking.LocalPlayer.displayName == _adminPlayers) return;
	    }
	    _videoPlayerCanvas.SetActive(!_videoPlayerCanvas.activeSelf);
	    _staffDoor.SetActive(!_staffDoor.activeSelf);
	}
	
	public void _ToggleTargetTrue()
	{
	    Debug.Log("d: World event mode true request received");
            _gfxButtonOff.SetActive(false);
	    _gfxButtonOn.SetActive(true);
	    _isEventOn = true;
	    //staff are immune to the gameobject toggle section
	    foreach(string _adminPlayers in _eventAdmins) {
                if (Networking.LocalPlayer.displayName == _adminPlayers) return;
	    }
	    _videoPlayerCanvas.SetActive(false);
	    _staffDoor.SetActive(true);
	}
	
	public void _ToggleTargetFalse()
	{
	    Debug.Log("d: World event mode false request received");
	    _gfxButtonOff.SetActive(true);
	    _gfxButtonOn.SetActive(false);
	    _isEventOn = false;
	    //staff are immune to the gameobject toggle section
	    foreach(string _adminPlayers in _eventAdmins) {
                if (Networking.LocalPlayer.displayName == _adminPlayers) return;
	    }
	    _videoPlayerCanvas.SetActive(false);
	    _staffDoor.SetActive(true);
	}
}
