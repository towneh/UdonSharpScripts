
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class ModPlayers : UdonSharpBehaviour
{
	private InputField playerName;
	public Text textTarget;
	
    void Interact()
    {
		textTarget.text = this.playerName.text;
    }
}
