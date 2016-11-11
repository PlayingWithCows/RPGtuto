using UnityEngine;
using System.Collections;

public class NPC : Interactable {

	public string[] dialogue;
	public string NPCName;

	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue (dialogue, NPCName);
		Debug.Log ("Interacted with NPC");
	}
}
