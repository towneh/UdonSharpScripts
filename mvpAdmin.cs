
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class mvpAdmin : UdonSharpBehaviour
{
    public GameObject[] adminObjects;
    public string[] adminUsers;


    public void Start()
    {
        foreach(string adminPlayers in adminUsers) {
            if (Networking.LocalPlayer.displayName == adminPlayers) {
                 foreach(GameObject go in adminObjects) {
                  go.SetActive(true);
                 }
             }
         }
    }
}