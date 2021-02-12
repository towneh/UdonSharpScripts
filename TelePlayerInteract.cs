
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TelePlayerInteract : UdonSharpBehaviour
{
	public Transform[] teleportTargets;
		
    public override void Interact()
    {
		int i;
		i = Random.Range(0, teleportTargets.Length);
		Networking.LocalPlayer.TeleportTo(teleportTargets[i].position, teleportTargets[i].rotation);
    }
}
