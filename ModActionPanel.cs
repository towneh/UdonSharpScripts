
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class ModActionPanel : UdonSharpBehaviour
{
	public Text targetPlayerName;
	private VRCPlayerApi targetPlayer;
	private Vector3 targetPlayerPos;
	private Quaternion targetPlayerRot;
	
	void DJBoothAccess()
	{
		
	}
	
	void StaffRoomAccess()
	{
		
	}
	
	void TeleportTo()
	{
		//var localPlayer = Networking.LocalPlayer;
		//targetPlayer = .targetPlayerName
		//targetPlayerPos = targetPlayer.GetPosition();
		//targetPlayerRot = targetPlayer.GetRotation();
		//localPlayer.TeleportTo(targetPlayerPos, targetPlayerRot);
	}
	
	void Yeet()
	{
		
	}
}
