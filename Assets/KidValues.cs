using UnityEngine;
using System.Collections;

public class KidValues : MonoBehaviour {
	
	public string[] kidNames;
	public string[] naughtyNiceEvent1;
	public string[] naughtyNiceEvent2;
	public string[] naughtyNiceEvent3;
	public string[] naughtyNiceEvent4;
	public string[] naughtyNiceEvent5;
	
	public string[] gift1;
	public string[] gift2;
	public string[] gift3;
	public string[] gift4;
	public string[] gift5;
	
	public Sprite[] backgroundSprites;
	public Sprite[] clothingSprites;
	public Sprite[] faceSprites;
	public Sprite[] eyeSprites;
	public Sprite[] mouthSprites;
	public Sprite[] hairSprites;
	public Sprite[] portraitSprites;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	public string naughtyNiceString(int nNlevel){
		if (nNlevel==1){
			return naughtyNiceEvent1[Random.Range(0,naughtyNiceEvent1.Length)];
		} 
		if (nNlevel==2){
			return naughtyNiceEvent2[Random.Range(0,naughtyNiceEvent2.Length)];
		}
		if (nNlevel==3){
			return naughtyNiceEvent3[Random.Range(0,naughtyNiceEvent3.Length)];
		}
		if (nNlevel==4){
			return naughtyNiceEvent4[Random.Range(0,naughtyNiceEvent4.Length)];
		}
		if (nNlevel==5){
			return naughtyNiceEvent5[Random.Range(0,naughtyNiceEvent5.Length)];
		} else {
			return "Not in range";
		}
	}
	
	public string giftString(int giftLevel){
		if (giftLevel==1){
			return gift1[Random.Range(0,gift1.Length)];
		} 
		if (giftLevel==2){
			return gift2[Random.Range(0,gift2.Length)];
		}
		if (giftLevel==3){
			return gift3[Random.Range(0,gift3.Length)];
		}
		if (giftLevel==4){
			return gift4[Random.Range(0,gift4.Length)];
		}
		if (giftLevel==5){
			return gift5[Random.Range(0,gift5.Length)];
		} else {
			return "Not in range";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
