
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class FireTheWorks : UdonSharpBehaviour
{   
    public GameObject target;
    private float cooldownStart;
	  private float currentTime;
	  private bool cooldownActive;
    
    public override void Interact()
	  {
		  CheckCooldown();
		  if (cooldownActive) return;
		  else {
		    SendCustomNetworkEvent(NetworkEventTarget.All, "TriggerTarget");
		  }
	  }
	
	  public override void OnPlayerJoined(VRCPlayerApi player)
	  {
		  if (Networking.IsMaster)
		  {
			  if (cooldownActive)
			  {
				  //How do I pass "cooldownStart" float value to late joiner if "cooldownActive" boolean is true?
			  }
		  }
	  }
	
	  public void UpdateCooldown()
	  {
		  cooldownStart = Networking.GetServerTimeInMilliseconds();
	  }
	
	  public void CheckCooldown()
	  {
		  currentTime = Networking.GetServerTimeInMilliseconds();
		  if (cooldownStart == 0) {
			  cooldownActive = false;
		  }
		  else if (currentTime - cooldownStart <= 300000) { 
			  cooldownActive = true;
		  }
		  else {
			  cooldownActive = false;
		  }
	  }
	
	  public void TriggerTarget()
	  {
		UpdateCooldown();
		target.SetActive(true);
		Invoke(target.SetActive(false),15f);
	  }
}
