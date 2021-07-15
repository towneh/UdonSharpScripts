
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DJStepToggle : UdonSharpBehaviour
{
   public bool _isShort;
   public GameObject djStepTarget;
		
   void Start() {
      _isShort = false;
   }
	
   public override void Interact()
   {
      _ToggleDJStep();
   }
	
   public void _ToggleDJStep()
   {
      _isShort = !_isShort;
      djStepTarget.SetActive(_isShort);
   }
}
