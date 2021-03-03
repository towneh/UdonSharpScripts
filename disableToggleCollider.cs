
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class disableToggleCollider : UdonSharpBehaviour
{
	public Toggle[] disableMainToggle;
	public Toggle[] disableStaffToggle;
	
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;
			foreach(Toggle t in disableMainToggle) {
				if(t.isOn); t.isOn = false;
			}
	}

	public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;
			foreach(Toggle t in disableStaffToggle) {
				if(t.isOn); t.isOn = false;
			}
	}
}