using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public static DialogueSystem Instance { get; set; }
	public List<string> dialogueLines = new List<string>();
	public string npcName;

	public GameObject dialoguePanel;

	Button continueButton;
	Text dialogueText, nameText;
	int dialogueIndex;

	void Awake(){
		if (Instance != null && Instance != this) {
		
			Destroy (gameObject);
		} else {
		
			Instance = this;
		}
		continueButton = dialoguePanel.transform.FindChild ("Continue").GetComponent<Button> ();
		dialogueText = dialoguePanel.transform.FindChild ("DialogueText").GetComponent<Text> ();
		nameText = dialoguePanel.transform.FindChild ("Name").GetComponentInChildren<Text> ();

		continueButton.onClick.AddListener (delegate {
			ContinueDialogue();
		});

		dialoguePanel.SetActive (false);

	}

	public void ContinueDialogue(){
		if (dialogueIndex < dialogueLines.Count - 1) {
			dialogueIndex++;
			dialogueText.text = dialogueLines [dialogueIndex];
		} else {
		
			dialoguePanel.SetActive (false);
		
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateDialogue (){
		dialogueText.text = dialogueLines [dialogueIndex];
		nameText.text = npcName;
		dialoguePanel.SetActive (true);
	}

	public void AddNewDialogue(string[] lines, string NPCName)
	{
		this.npcName = NPCName;
		dialogueLines = new List<string> (lines.Length);
		dialogueLines.AddRange (lines);
		Debug.Log (dialogueLines.Count);
		dialogueIndex = 0;
		CreateDialogue ();
	}


}
