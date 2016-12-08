using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class DebugIntro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DialogueManager.StartConversation ("TestConversation01");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
