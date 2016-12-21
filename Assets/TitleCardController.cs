using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleCardController : MonoBehaviour {
	
	public GameObject UIcanvas;
	
	// Use this for initialization
	void Start () {
		UIcanvas.SetActive(false);
		Invoke("EnableUI",12f);
	}
	
	void EnableUI(){
		UIcanvas.SetActive(true);
		
	}
	
	public void LoadIntroLevel(){
		SceneManager.LoadScene ("IntroScene",LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
