using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour {
	
	
	public float cheer;
	public float budget;
	
	public bool failureStateTriggered = false;
	
	public Text playerValuesText;
	public Text kidText;
	public GameController gameController;
	
	public string[] overcheerFailureStrings;
	public string[] undercheerFailureStrings;
	public string[] overbudgetFailureStrings;
	public string[] underbudgetFailureStrings;
	
	public GameObject cheerPipe;
	public GameObject workShopPipe;
	public GameObject blackOutCard;
	
	
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
		blackOutCard.SetActive(false);
	}
	
	void UpdateKidText(){
		kidText.text = "You judged " + gameController.kidsServed.ToString() + " kids \nMerry Christmas!\n\nHigh Score: "+ PlayerPrefsManager.GetHighScore().ToString();
	}
	
	
	
	public void FailureStates(int failureCode){
		if(!failureStateTriggered){
			blackOutCard.SetActive(true);
			failureStateTriggered = true;
			gameController.GameOverMusic();
			if(failureCode==1){
				playerValuesText.alignment = TextAnchor.UpperCenter;
				playerValuesText.text = overcheerFailureStrings[Random.Range(0,overcheerFailureStrings.Length)];
			}
			if(failureCode==2){
				playerValuesText.alignment = TextAnchor.UpperCenter;
				playerValuesText.text = undercheerFailureStrings[Random.Range(0,undercheerFailureStrings.Length)];
			}
			if(failureCode==3){
				playerValuesText.alignment = TextAnchor.UpperCenter;
				playerValuesText.text = overbudgetFailureStrings[Random.Range(0,overbudgetFailureStrings.Length)];
			}
			if(failureCode==4){
				playerValuesText.alignment = TextAnchor.UpperCenter;
				playerValuesText.text = underbudgetFailureStrings[Random.Range(0,underbudgetFailureStrings.Length)];
			}
		}
	}
	
	public void ClearValuesText(){
		playerValuesText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (cheer > 100){
			FailureStates(1);
			cheerPipe.transform.localScale = new Vector3(1,1,1);
			gameController.failureTriggered = true;
			UpdateKidText();
		} else {
			if (cheer < 0){
				FailureStates(2);
				cheerPipe.transform.localScale = new Vector3(1,0,1);
				gameController.failureTriggered = true;
				UpdateKidText();
			} else {
				if (budget > 100){
					FailureStates(3);
					workShopPipe.transform.localScale = new Vector3(1,1,1);
					gameController.failureTriggered = true;
					UpdateKidText();
				} else {
					if(!failureStateTriggered){
					playerValuesText.alignment = TextAnchor.UpperLeft;
						//playerValuesText.text = "Cheer: " + cheer.ToString() + "\nWorkshop Magic: " + budget.ToString();
						
						cheerPipe.transform.localScale = new Vector3(1, (cheer/100f),1);
						workShopPipe.transform.localScale = new Vector3(1, (budget/100f),1);
					}
					
					if (budget < 0){
						FailureStates(4);
						workShopPipe.transform.localScale = new Vector3(1,0,1);
						gameController.failureTriggered = true;
						UpdateKidText();
					}
				}
			}
		}

	
	}
}
