
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class mvpBanlist : UdonSharpBehaviour
{
    public GameObject[] banYeeter;
    public string[] bannedUsers;


    public void Start()
    {
        foreach(string bannedPlayers in bannedUsers) {
            if (Networking.LocalPlayer.displayName == bannedPlayers) {
                 foreach(GameObject go in banYeeter) {
                  go.SetActive(true);
                 }
             }
         }
    }
}