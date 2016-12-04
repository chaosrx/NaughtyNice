using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour {
	
	
	public float cheer;
	public float budget;
	
	public Text playerValuesText;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (cheer > 100){
			playerValuesText.text = "Overcheer Failure Triggered";
			
		} else {
			if (cheer < 0){
				playerValuesText.text = "Undercheer Failure Triggered";
			} else {
				if (budget > 100){
					playerValuesText.text = "Overbudget Failure Triggered";
				} else {
					playerValuesText.text = "Cheer: " + cheer.ToString() + "\nWorkshop Magic: " + budget.ToString();
					
					if (budget < 0){
						playerValuesText.text = "Underbudget Failure Triggered";
					}
				}
			}
		}

	
	}
}
