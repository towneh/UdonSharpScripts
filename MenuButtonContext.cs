
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using VRC.SDKBase;
using VRC.Udon;

public class MenuButtonContext : UdonSharpBehaviour
{
	public UdonSharpBehaviour toggleTarget;
	public AudioSource audioEnable;
	public AudioSource audioDisable;
	
	public UdonSharpBehaviour[] disableRelatedTargets;
	
	void Interact()
	{
		if ((bool)toggleTarget.GetProgramVariable("Active"))
		{
			toggleTarget.SendCustomEvent("Disable");
			audioDisable.Play();
		}
		else
		{
			toggleTarget.SendCustomEvent("Enable");
			audioEnable.Play();
		}
		
		foreach (UdonSharpBehaviour b in disableRelatedTargets) {
			if ((bool)b.GetProgramVariable( name: "Active")) {
				b.SendCustomEvent("Disable");
			}
		}
			
	}
}