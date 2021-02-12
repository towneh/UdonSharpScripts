
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TelePlayerCollider : UdonSharpBehaviour
{
	public Transform[] teleportTargets;
		
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;
		int i;
		i = Random.Range(0, teleportTargets.Length);
		Networking.LocalPlayer.TeleportTo(teleportTargets[i].position, teleportTargets[i].rotation);
    }

	public override void OnPlayerTriggerStay(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;
		int i;
		i = Random.Range(0, teleportTargets.Length);
		Networking.LocalPlayer.TeleportTo(teleportTargets[i].position, teleportTargets[i].rotation);
    }
}
