
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class VRSLToggle : UdonSharpBehaviour
{
	 public MeshRenderer[] _vrslToggle;
	 //public Component[] _vrslToggle;
	
	 public void _DisableVRSL()
	 {
      //vrslToggle = GetComponentsInChildren<MeshRenderer>();
	    foreach(MeshRenderer _mr in _vrslToggle)
         _mr.enabled = false;
	 }
	
	 public void _EnableVRSL()
	 {
      //vrslToggle = GetComponentsInChildren<MeshRenderer>();
      foreach(MeshRenderer _mr in _vrslToggle)
         _mr.enabled = true;
	 }
}
