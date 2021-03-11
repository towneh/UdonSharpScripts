
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuPanelEnable : UdonSharpBehaviour
{
	public GameObject toggleButtonOff;
	public GameObject toggleButtonOn;
	public GameObject toggleMenu;
	public GameObject togglePanel;
	public AudioSource audioEnableSrc;
	public AudioClip audioEnableClip;
	
    void Interact()
    {
		if (toggleButtonOff.activeSelf)
		{
			toggleButtonOff.SetActive(false);
			toggleButtonOn.SetActive(true);
			toggleMenu.SetActive(true);
			togglePanel.SetActive(true);
			audioEnableSrc.clip = audioEnableClip;
			audioEnableSrc.Play();
		} 
    }
}
