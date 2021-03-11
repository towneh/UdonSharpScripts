
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class mvpBannedUsers : UdonSharpBehaviour
{
    public GameObject[] banAccess;
    public string[] bannedUsers;


    public void Start()
    {
        foreach(string bannedPlayers in bannedUsers) {
            if (Networking.LocalPlayer.displayName == bannedPlayers) {
                 foreach(GameObject go in banAccess) {
                  go.SetActive(false);
                 }
             }
         }
    }
}