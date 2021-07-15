
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuButtonEnable : UdonSharpBehaviour
{
	public GameObject _toggleButtonOff;
	public GameObject _toggleButtonOn;
	public AudioSource _audioEnableSrc;
	public AudioClip _audioEnableClip;
	
    void Interact()
    {
		if (_toggleButtonOff.activeSelf)
		{
			_toggleButtonOff.SetActive(false);
			_toggleButtonOn.SetActive(true);
			_audioEnableSrc.PlayOneShot(_audioEnableClip);
		} 
    }
}
