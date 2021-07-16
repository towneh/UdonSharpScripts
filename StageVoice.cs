
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StageVoice : UdonSharpBehaviour
{
    [Header("Voice Box Area")]
    [Tooltip("The collider which influences voice range")]
    public Collider _voiceBox;
	
    [Header("Original Player Voice")]
    [Tooltip("Existing player volume")]
    [Range(0f, 24f)]
    public float _originalVoiceGain = 15f;

    [Tooltip("The end of the range for hearing a user's voice")]
    public float _originalVoiceFar = 25f;

    [Tooltip("The near radius in meters where player audio starts to fall off, it is recommended to keep this at 0")]
    public float _originalVoiceNear = 0f;
	
    [Header("Modified Player Voice")]
    [Tooltip("New player volume")]
    [Range(-20f, 24f)]
    public float _modifiedVoiceGain = -20f;

    [Tooltip("The end of the range for hearing a user's voice")]
    public float _modifiedVoiceFar = 500f;

    [Tooltip("The near radius in meters where player audio starts to fall off, it is recommended to keep this at 0")]
    public float _modifiedVoiceNear = 250f;
	
    public void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (!player.isLocal) {
	    // Player voice
            player.SetVoiceGain(_modifiedVoiceGain);
            player.SetVoiceDistanceFar(_modifiedVoiceFar);
            player.SetVoiceDistanceNear(_modifiedVoiceNear);
	}
    }
	
    public void OnPlayerTriggerStay(VRCPlayerApi player)
    {
        if (!player.isLocal) {
	    // Player voice
            player.SetVoiceGain(_modifiedVoiceGain);
            player.SetVoiceDistanceFar(_modifiedVoiceFar);
            player.SetVoiceDistanceNear(_modifiedVoiceNear);
	}
    }
	
    public void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (!player.isLocal) {
	    // Player voice
            player.SetVoiceGain(_originalVoiceGain);
            player.SetVoiceDistanceFar(_originalVoiceFar);
            player.SetVoiceDistanceNear(_originalVoiceNear);
 	}
    }
}
