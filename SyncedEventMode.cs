
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
    [Tooltip("AudioLink Canvas")]
    public GameObject _audiolinkCanvas;
	
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
	
    private bool _isEventOn;
    
	private void Start() 
	{
	    _isEventOn = false;
	}
	
	/* // You can ignore the below Interact function and use UT Interact Trigger instead if you want (commented out by default)
	public override void Interact()
	{
	    //we only want this to work for staff
	    foreach(string _adminPlayers in _eventAdmins) {
                if (Networking.LocalPlayer.displayName == _adminPlayers) {
	            SendCustomNetworkEvent(NetworkEventTarget.All, "ToggleTarget");
		}
	    }
	} */
	   
	public override void OnPlayerJoined(VRCPlayerApi player)
	{
	    if (Networking.IsMaster)
	        {
		    if (_isEventOn)
		        {
			    //Debug.Log("[SyncedEventMode] Late join event True sent");
			    SendCustomNetworkEvent(NetworkEventTarget.All, "ToggleTargetTrue");
			}
			else
			{
			    //Debug.Log("[SyncedEventMode] Late join event False sent");
			    SendCustomNetworkEvent(NetworkEventTarget.All, "ToggleTargetFalse");
			}
		}
	}
	
	public void ToggleTarget()
	{
	    //Debug.Log("[SyncedEventMode] World event mode toggle request received");
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
	    foreach(string _adminPlayers in _eventAdmins) {
                if (Networking.LocalPlayer.displayName == _adminPlayers) return;
	    }
            _videoPlayerCanvas.SetActive(!_videoPlayerCanvas.activeSelf);
	    _staffDoor.SetActive(!_staffDoor.activeSelf);
	    _audiolinkCanvas.GetComponent<Canvas> ().enabled = !_isEventOn;
	}
	
	public void ToggleTargetTrue()
	{
	    //Debug.Log("[SyncedEventMode] World event mode true request received");
	    _gfxButtonOff.SetActive(false);
	    _gfxButtonOn.SetActive(true);
	    _isEventOn = true;
	    //staff are immune to the gameobject toggle section
	    foreach(string _adminPlayers in _eventAdmins) {
                if (Networking.LocalPlayer.displayName == _adminPlayers) return;
	    }
	    _videoPlayerCanvas.SetActive(false);
	    _staffDoor.SetActive(true);
	    _audiolinkCanvas.GetComponent<Canvas> ().enabled = false;
	}
	
	public void ToggleTargetFalse()
	{
	    //Debug.Log("[SyncedEventMode] World event mode false request received");
            _gfxButtonOff.SetActive(true);
	    _gfxButtonOn.SetActive(false);
	    _isEventOn = false;
	    //staff are immune to the gameobject toggle section
	    foreach(string _adminPlayers in _eventAdmins) {
                if (Networking.LocalPlayer.displayName == _adminPlayers) return;
	    }
	    _videoPlayerCanvas.SetActive(true);
	    _staffDoor.SetActive(false);
	    _audiolinkCanvas.GetComponent<Canvas> ().enabled = true;
	}
}
