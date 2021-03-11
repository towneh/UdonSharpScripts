
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuPanelDisable : UdonSharpBehaviour
{
	public GameObject toggleButtonOff;
	public GameObject toggleButtonOn;
	public GameObject toggleMenu1;
	public GameObject toggleMenu2;
	public GameObject togglePanel;
	public AudioSource audioDisableSrc;
	public AudioClip audioDisableClip;
	
    void Interact()
    {
		if (toggleButtonOn.activeSelf)
		{
			toggleButtonOff.SetActive(true);
			toggleButtonOn.SetActive(false);
			toggleMenu1.SetActive(false);
			toggleMenu2.SetActive(false);
			togglePanel.SetActive(false);
			audioDisableSrc.clip = audioDisableClip;
			audioDisableSrc.Play();
		}
    }
}
