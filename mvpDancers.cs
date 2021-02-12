
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class mvpDancers : UdonSharpBehaviour
{
    public GameObject[] dancerObjects;
    public string[] dancerUsers;


    public void Start()
    {
        foreach(string dancerPlayers in dancerUsers) {
            if (Networking.LocalPlayer.displayName == dancerPlayers) {
                 foreach(GameObject go in dancerObjects) {
                  go.SetActive(true);
                 }
             }
         }
    }
}