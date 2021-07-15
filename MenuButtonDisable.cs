
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuButtonDisable : UdonSharpBehaviour
{
   public GameObject _toggleButtonOff;
   public GameObject _toggleButtonOn;
   public AudioSource _audioDisableSrc;
   public AudioClip _audioDisableClip;
	
   void Interact()
   {
      if (_toggleButtonOn.activeSelf)
         {
            _toggleButtonOff.SetActive(true);
            _toggleButtonOn.SetActive(false);
            _audioDisableSrc.PlayOneShot(_audioDisableClip);
	}
    }
}
