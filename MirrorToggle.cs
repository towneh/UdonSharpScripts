
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MirrorToggle : UdonSharpBehaviour
{
	public bool Active;
	public GameObject checkbox;

	public void Enable()
	{
		checkbox.SetActive(true);
		Active = true;
	}

	public void Disable()
	{
		checkbox.SetActive(false);
		Active = false;
	}
}