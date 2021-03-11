
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuButtonEnable : UdonSharpBehaviour
{
	public GameObject toggleButtonOff;
	public GameObject toggleButtonOn;
	public AudioSource audioEnableSrc;
	public AudioClip audioEnableClip;
	
    void Interact()
    {
		if (toggleButtonOff.activeInHierarchy)
		{
			toggleButtonOff.SetActive(false);
			toggleButtonOn.SetActive(true);
			audioEnableSrc.clip = audioEnableClip;
			audioEnableSrc.Play();
		} 
    }
}
