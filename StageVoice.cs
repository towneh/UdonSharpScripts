
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StageVoice : UdonSharpBehaviour
{
    [Header("Voice Area")]
    [Tooltip("The collider which influences voice range")]
    public Collider voiceBox;
	
    [Header("Player voice")]
    [Tooltip("Adjusts the player volume")]
    [Range(0f, 24f)]
    public float voiceGain = 15f;

    [Tooltip("The end of the range for hearing a user's voice")]
    public float voiceFar = 25f;

    [Tooltip("The near radius in meters where player audio starts to fall off, it is recommended to keep this at 0")]
    public float voiceNear = 0f;
	
    public void OnTriggerEnter(Collider voiceBox)
    {
        
    }
	
    public void OnTriggerStay(Collider voiceBox)
    {
        
    }
	
    public void OnTriggerExit(Collider voiceBox)
    {
        
    }
}
