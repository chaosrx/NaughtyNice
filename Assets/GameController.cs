using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	private KidValues kidValues;
	private Kid kid;
	private PlayerValues playerValues;
	
	public int kidsServed = 0;
	
	public bool failureTriggered = false;
	
	public Button debugResetButton;
	
	public GameObject kidCardPrefab;
	
	public GameObject nextKidObject;
	public GameObject currentKidObject;
	public GameObject lastKidObject;
	
	public AudioClip positiveSound;
	public AudioClip negativeSound;
	public AudioClip gameOverMusic;
	
	
	private Animator currentKidAnimator;
	public Animator naughtyNicePopup;
	private SFXManager sfxManager;
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		debugResetButton.gameObject.SetActive(false);
		kidValues = FindObjectOfType<KidValues>().GetComponent<KidValues>();
		kid = FindObjectOfType<Kid>().GetComponent<Kid>();
		playerValues = FindObjectOfType<PlayerValues>().GetComponent<PlayerValues>();
		currentKidAnimator = currentKidObject.GetComponentInChildren<Animator>();
		sfxManager = FindObjectOfType<SFXManager>().GetComponent<SFXManager>();
		musicManager = FindObjectOfType<MusicManager>().GetComponent<MusicManager>();
		
		RandomizeKid();
	}
	
	public void RandomizeKid(){
		kid.kidName = kidValues.kidNames[Random.Range(0,kidValues.kidNames.Length)];
		kid.believerYears = Random.Range(1,8);
		kid.naughtyNiceLevel = Random.Range(1,6);
		kid.giftLevel = Random.Range(1,6);
		kid.UpdateText();
	}
	
	public void SwitchKidCardsGenerateNew(){
		//Move current kid out of the way
		Transform currentKidChild = currentKidObject.transform.GetChild(0);
		currentKidChild.transform.parent = lastKidObject.transform;
		
		//Bring next kid forward
		Invoke ("BringNextKidForward",0.5f);
		
	}
	
	private void BringNextKidForward(){
		Transform nextKidChild = nextKidObject.transform.GetChild(0);
		nextKidChild.transform.parent = currentKidObject.transform;
		KidCard nextKidCard = nextKidChild.GetComponent<KidCard>();
		nextKidCard.BringCardForward();
		currentKidAnimator = currentKidObject.GetComponentInChildren<Animator>();
		
		//Repopulate next kid
		GameObject KidCard = Instantiate(kidCardPrefab,transform.position,Quaternion.identity) as GameObject;
		KidCard.transform.parent = nextKidObject.transform;
		

	}
	
	public void Naughty(){
		sfxManager.playSound(negativeSound);
		naughtyNicePopup.SetTrigger("Naughty");
		int CheerReduction = Mathf.CeilToInt((kid.believerYears/kid.naughtyNiceLevel) * kid.giftLevel * 2f);
		if (CheerReduction == 0){
			CheerReduction = 5;
			Debug.Log("0 cheer triggered, adding 5");
		}
		Debug.Log("Cheer reduction by: " + CheerReduction);
		
		playerValues.cheer -= CheerReduction;
		playerValues.budget += kid.giftLevel * 2;
		kidsServed++;
		SwitchKidCardsGenerateNew();
		RandomizeKid();
	}
	
	public void Nice(){
		sfxManager.playSound(positiveSound);
		
		naughtyNicePopup.SetTrigger("Nice");
		
		playerValues.cheer += Mathf.CeilToInt((kid.believerYears*kid.naughtyNiceLevel)/2);
		playerValues.budget -= kid.giftLevel * 2;
		kidsServed++;
		SwitchKidCardsGenerateNew();
		RandomizeKid();
	}
	
	public void DebugReset(){
		//probably going to replace this with more robust logic once I start polishing
		failureTriggered = false;
		//naughtyNiceButtons.gameObject.SetActive(true);
		debugResetButton.gameObject.SetActive(false);
		
		kidsServed = 0;
		playerValues.cheer = 65;
		playerValues.budget = 65;
		playerValues.failureStateTriggered = false;
		playerValues.ClearValuesText();
		RandomizeKid();
		
		
	}
	
	public void GameOverMusic(){
		musicManager.playSound(gameOverMusic);
	}
	
	public void restartCurrentScene()
	{
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		if (failureTriggered){
			PlayerPrefsManager.CheckSetHighScore(kidsServed);
			
			debugResetButton.gameObject.SetActive(true);
		} else{
			if (SwipeManager.IsSwipingLeft()){
				currentKidAnimator.SetTrigger("SwipeLeft");
				Naughty();
			}
			if (SwipeManager.IsSwipingRight()){
				currentKidAnimator.SetTrigger("SwipeRight");
				Nice();
			}
		}
		
	}
	
	
	
}
