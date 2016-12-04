using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	private KidValues kidValues;
	private Kid kid;
	private PlayerValues playerValues;
	
	public int kidsServed = 0;
	
	public bool failureTriggered = false;
	
	public Button debugResetButton;
	
	public GameObject naughtyNiceButtons;
	
	// Use this for initialization
	void Start () {
		debugResetButton.gameObject.SetActive(false);
		kidValues = FindObjectOfType<KidValues>().GetComponent<KidValues>();
		kid = FindObjectOfType<Kid>().GetComponent<Kid>();
		playerValues = FindObjectOfType<PlayerValues>().GetComponent<PlayerValues>();
		RandomizeKid();
	}
	
	public void RandomizeKid(){
		kid.kidName = kidValues.kidNames[Random.Range(0,kidValues.kidNames.Length)];
		kid.believerYears = Random.Range(1,8);
		kid.naughtyNiceLevel = Random.Range(1,6);
		kid.giftLevel = Random.Range(1,6);
		kid.UpdateText();
	}
	
	public void Naughty(){
		int debugCheerReduction = Mathf.CeilToInt((kid.naughtyNiceLevel/kid.giftLevel) * kid.believerYears);
		Debug.Log("Cheer reduction by: " + debugCheerReduction);
		playerValues.cheer -= Mathf.CeilToInt((kid.believerYears/kid.naughtyNiceLevel) * kid.giftLevel * 2f);
		playerValues.budget += kid.giftLevel * 2;
		kidsServed++;
		RandomizeKid();
	}
	
	public void Nice(){
		playerValues.cheer += Mathf.CeilToInt((kid.believerYears*kid.naughtyNiceLevel)/2);
		playerValues.budget -= kid.giftLevel * 2;
		kidsServed++;
		RandomizeKid();
	}
	
	public void DebugReset(){
		//probably going to replace this with more robust logic once I start polishing
		failureTriggered = false;
		naughtyNiceButtons.gameObject.SetActive(true);
		debugResetButton.gameObject.SetActive(false);
		
		kidsServed = 0;
		playerValues.cheer = 75;
		playerValues.budget = 75;
		RandomizeKid();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (failureTriggered){
			debugResetButton.gameObject.SetActive(true);
			naughtyNiceButtons.gameObject.SetActive(false);
		}
	}
}
