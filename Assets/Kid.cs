using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kid : MonoBehaviour {
	
	public string kidName;
	public int believerYears;
	public int naughtyNiceLevel;
	public int giftLevel;
	
	
	public Text kidText;
	public KidValues kidValues;
	
	// Use this for initialization
	void Start () {
		//		kidValues = FindObjectOfType<KidValues>().GetComponent<KidValues>();
	}
	
	public void UpdateText(){
		kidText.text = "Name: " + kidName +
			"\n Believer for " + believerYears.ToString() + " years" +
			"\n\n" + kidValues.naughtyNiceString(naughtyNiceLevel) +
			"\n\n Wants " + kidValues.giftString(giftLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
