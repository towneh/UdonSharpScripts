
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TelePlayerInteract : UdonSharpBehaviour
{
	public Transform[] _teleportTargets;
	
	public override void Interact()
	{
		int i;
		i = Random.Range(0, _teleportTargets.Length);
		Networking.LocalPlayer.TeleportTo(_teleportTargets[i].position, _teleportTargets[i].rotation);
	}
}
