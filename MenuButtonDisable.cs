
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuButtonDisable : UdonSharpBehaviour
{
	public GameObject toggleButtonOff;
	public GameObject toggleButtonOn;
	public AudioSource audioDisableSrc;
	public AudioClip audioDisableClip;
	
    void Interact()
    {
		if (toggleButtonOn.activeSelf)
		{
			toggleButtonOff.SetActive(true);
			toggleButtonOn.SetActive(false);
			audioDisableSrc.clip = audioDisableClip;
			audioDisableSrc.Play();
		}
    }
}
