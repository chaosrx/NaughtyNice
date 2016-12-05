using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour {
	
	
	public float cheer;
	public float budget;
	
	public Text playerValuesText;
	public Text kidText;
	public GameController gameController;
	
	public string[] overcheerFailureStrings;
	public string[] undercheerFailureStrings;
	public string[] overbudgetFailureStrings;
	public string[] underbudgetFailureStrings;
	
	
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
	}
	
	void UpdateKidText(){
		kidText.text = "Game Over \n You judged " + gameController.kidsServed.ToString() + " kids \n Merry Christmas!";
	}
	
	public bool failureStateTriggered = false;
	
	public void FailureStates(int failureCode){
		if(!failureStateTriggered){
			failureStateTriggered = true;
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
	
	// Update is called once per frame
	void Update () {
		if (cheer > 100){
			FailureStates(1);
			gameController.failureTriggered = true;
			UpdateKidText();
		} else {
			if (cheer < 0){
				FailureStates(2);
				gameController.failureTriggered = true;
				UpdateKidText();
			} else {
				if (budget > 100){
					FailureStates(3);
					gameController.failureTriggered = true;
					UpdateKidText();
				} else {
					if(!failureStateTriggered){
					playerValuesText.alignment = TextAnchor.UpperLeft;
						playerValuesText.text = "Cheer: " + cheer.ToString() + "\nWorkshop Magic: " + budget.ToString();
					}
					
					if (budget < 0){
						FailureStates(4);
						gameController.failureTriggered = true;
						UpdateKidText();
					}
				}
			}
		}

	
	}
}
