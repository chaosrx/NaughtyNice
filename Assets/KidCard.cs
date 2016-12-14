using UnityEngine;
using System.Collections;

public class KidCard : MonoBehaviour {
	
	public SpriteRenderer backgroundSprite;
	public SpriteRenderer portraitSprite;
	public SpriteRenderer clothesSprite;
	public SpriteRenderer faceSprite;
	public SpriteRenderer eyesSprite;
	public SpriteRenderer mouthSprite;
	public SpriteRenderer hairSprite;
	
	private KidValues kidValues;
	
	// Use this for initialization
	void Start () {
		kidValues = FindObjectOfType<KidValues>().GetComponent<KidValues>();
		
		backgroundSprite.sprite = kidValues.backgroundSprites[Random.Range(0,kidValues.backgroundSprites.Length)];
		portraitSprite.sprite = kidValues.portraitSprites[Random.Range(0,kidValues.portraitSprites.Length)];
		clothesSprite.sprite = kidValues.clothingSprites[Random.Range(0,kidValues.clothingSprites.Length)];
		faceSprite.sprite = kidValues.faceSprites[Random.Range(0,kidValues.faceSprites.Length)];
		eyesSprite.sprite = kidValues.eyeSprites[Random.Range(0,kidValues.eyeSprites.Length)];
		mouthSprite.sprite = kidValues.mouthSprites[Random.Range(0,kidValues.mouthSprites.Length)];
		hairSprite.sprite = kidValues.hairSprites[Random.Range(0,kidValues.hairSprites.Length)];
	}
	
	public void BringCardForward(){
		backgroundSprite.sortingOrder = 8;
		portraitSprite.sortingOrder = 9;
		clothesSprite.sortingOrder = 10;
		faceSprite.sortingOrder = 11;
		eyesSprite.sortingOrder = 12;
		mouthSprite.sortingOrder = 13;
		hairSprite.sortingOrder = 14;
	}
	
	public void DestroySelf(){
		Destroy(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
