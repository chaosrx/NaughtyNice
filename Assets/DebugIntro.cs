using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class DebugIntro : MonoBehaviour {
	
	public GameObject dialogueManager;

	// Use this for initialization
	void Start () {
		Invoke ("GameStart",3f);
	}
	
	void GameStart(){
		DialogueManager.StartConversation ("TestConversation01");
		
	}
	
	public void LoadMainGame(){
		SceneManager.LoadScene ("scene01", LoadSceneMode.Single);
		Destroy(dialogueManager);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
