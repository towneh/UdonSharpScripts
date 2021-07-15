
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AccessDJs : UdonSharpBehaviour
{
   public GameObject[] _djCollider;
   public string[] _djUsers;
   
   public void Start()
   {
      foreach(string _djPlayers in _djUsers) {
         if (Networking.LocalPlayer.displayName == _djPlayers) {
            foreach(GameObject go in _djCollider) {
               go.SetActive(false);
            }
         }
      }
   }
}
