
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TelePlayerCollider : UdonSharpBehaviour
{
	public Transform[] _teleportTargets;
		
	public override void OnPlayerTriggerEnter(VRCPlayerApi player)
	{
		if(player != Networking.LocalPlayer) return;
		int i;
		i = Random.Range(0, _teleportTargets.Length);
		Networking.LocalPlayer.TeleportTo(_teleportTargets[i].position, _teleportTargets[i].rotation);
	}

	public override void OnPlayerTriggerStay(VRCPlayerApi player)
	{
        	if(player != Networking.LocalPlayer) return;
		int i;
		i = Random.Range(0, _teleportTargets.Length);
		Networking.LocalPlayer.TeleportTo(_teleportTargets[i].position, _teleportTargets[i].rotation);
	}
}
