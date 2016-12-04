using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour {
	
	
	public float cheer;
	public float budget;
	
	public Text playerValuesText;
	public Text kidText;
	public GameController gameController;
	
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
	}
	
	void UpdateKidText(){
		kidText.text = "Game Over \n You judged " + gameController.kidsServed.ToString() + " kids \n Merry Christmas!";
	}
	
	// Update is called once per frame
	void Update () {
		if (cheer > 100){
			playerValuesText.text = "Overcheer Failure Triggered";
			gameController.failureTriggered = true;
			UpdateKidText();
		} else {
			if (cheer < 0){
				playerValuesText.text = "Undercheer Failure Triggered";
				gameController.failureTriggered = true;
				UpdateKidText();
			} else {
				if (budget > 100){
					playerValuesText.text = "Overbudget Failure Triggered";
					gameController.failureTriggered = true;
					UpdateKidText();
				} else {
					playerValuesText.text = "Cheer: " + cheer.ToString() + "\nWorkshop Magic: " + budget.ToString();
					
					if (budget < 0){
						playerValuesText.text = "Underbudget Failure Triggered";
						gameController.failureTriggered = true;
						UpdateKidText();
					}
				}
			}
		}

	
	}
}
