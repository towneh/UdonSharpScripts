
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AccessStaff : UdonSharpBehaviour
{
	 public GameObject[] _basicAccess;
   public GameObject[] _staffAccess;
   public string[] _eventAdmins;

   public void Start()
   {
	    if (Networking.LocalPlayer.isInstanceOwner) {
	       foreach(GameObject go in _basicAccess) {
            go.SetActive(false);
			   }
		  }
      foreach(string adminPlayers in _eventAdmins) {
         if (Networking.LocalPlayer.displayName == _adminPlayers) {
            foreach(GameObject go in _staffAccess) {
               go.SetActive(true);
            }
				    foreach(GameObject go in _basicAccess) {
				       go.SetActive(false);
				    }
         }
      }
   }
} 
