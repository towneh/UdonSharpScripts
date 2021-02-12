
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class mvpDJs : UdonSharpBehaviour
{
    public GameObject[] djCollider;
    public string[] djUsers;


    public void Start()
    {
        foreach(string djPlayers in djUsers) {
            if (Networking.LocalPlayer.displayName == djPlayers) {
                 foreach(GameObject go in djCollider) {
                  go.SetActive(false);
                 }
             }
         }
    }
}