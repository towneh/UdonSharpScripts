using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuCollider : UdonSharpBehaviour
{
    [Header("Canvas Target")]
    [Tooltip("Canvas GameObject to toggle")]
    public GameObject _menuTarget;
	
    public void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.isLocal) {
            _menuTarget.SetActive(true);
	      }
    }
	
    public void OnPlayerTriggerStay(VRCPlayerApi player)
    {
        if (player.isLocal) {
            _menuTarget.SetActive(true);
	      }
    }
	
    public void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (player.isLocal) {
            _menuTarget.SetActive(false);
 	      }
    }
}
