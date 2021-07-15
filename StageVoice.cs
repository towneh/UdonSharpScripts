
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StageVoice : UdonSharpBehaviour
{
    [Header("Voice Box Area")]
    [Tooltip("The collider which influences voice range")]
    public Collider voiceBox;
	
    [Header("Original Player Voice")]
    [Tooltip("Existing player volume")]
    [Range(0f, 24f)]
    public float originalVoiceGain = 15f;

    [Tooltip("The end of the range for hearing a user's voice")]
    public float originalVoiceFar = 25f;

    [Tooltip("The near radius in meters where player audio starts to fall off, it is recommended to keep this at 0")]
    public float originalVoiceNear = 0f;
	
    [Header("Modified Player Voice")]
    [Tooltip("New player volume")]
    [Range(-20f, 24f)]
    public float modifiedVoiceGain = -20f;

    [Tooltip("The end of the range for hearing a user's voice")]
    public float modifiedVoiceFar = 500f;

    [Tooltip("The near radius in meters where player audio starts to fall off, it is recommended to keep this at 0")]
    public float modifiedVoiceNear = 250f;
	
    public void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (!player.isLocal) {
	    // Player voice
            player.SetVoiceGain(modifiedVoiceGain);
            player.SetVoiceDistanceFar(modifiedVoiceFar);
            player.SetVoiceDistanceNear(modifiedVoiceNear);
	}
    }
	
    public void OnPlayerTriggerStay(VRCPlayerApi player)
    {
        if (!player.isLocal) {
	    // Player voice
            player.SetVoiceGain(modifiedVoiceGain);
            player.SetVoiceDistanceFar(modifiedVoiceFar);
            player.SetVoiceDistanceNear(modifiedVoiceNear);
	}
    }
	
    public void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (!player.isLocal) {
	    // Player voice
            player.SetVoiceGain(originalVoiceGain);
            player.SetVoiceDistanceFar(originalVoiceFar);
            player.SetVoiceDistanceNear(originalVoiceNear);
 	}
    }
}
