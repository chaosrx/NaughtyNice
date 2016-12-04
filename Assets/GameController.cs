using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	private KidValues kidValues;
	private Kid kid;
	private PlayerValues playerValues;
	
	// Use this for initialization
	void Start () {
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
		int debugCheerReduction = Mathf.CeilToInt(kid.believerYears*kid.naughtyNiceLevel/kid.giftLevel);
		Debug.Log("Cheer reduction by: " + debugCheerReduction);
		playerValues.cheer -= Mathf.CeilToInt((kid.believerYears/kid.naughtyNiceLevel) * kid.giftLevel * 2f);
		playerValues.budget += kid.giftLevel * 2;
		RandomizeKid();
	}
	
	public void Nice(){
		playerValues.cheer += Mathf.CeilToInt((kid.believerYears*kid.naughtyNiceLevel)/2);
		playerValues.budget -= kid.giftLevel * 2;
		RandomizeKid();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
