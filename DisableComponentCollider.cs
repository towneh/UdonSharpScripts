
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DisableComponentCollider : UdonSharpBehaviour
{
	//public Button[] disableComponents;
	public GameObject[] disableComponents;
	public GameObject[] enableComponents;

	public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
	/*	foreach(Button button in disableComponents) {
			if(button.gameObject.activeInHierarchy); button.onClick.Invoke();
		}*/ //we hate making our life easy don't we udon
		foreach (GameObject go in disableComponents) {
			if(go.activeInHierarchy); go.SetActive(false);
		}
		foreach (GameObject go in enableComponents) {
			if(go.activeInHierarchy); go.SetActive(true);
		}
	}
}