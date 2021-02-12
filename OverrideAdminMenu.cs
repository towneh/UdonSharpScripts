
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class OverrideAdminMenu : UdonSharpBehaviour
{
    public GameObject[] overrideAccess;
	
	public void OverrideButton()
	{
		foreach(GameObject go in overrideAccess) {
			go.SetActive(true);
		}
	}
}