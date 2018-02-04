using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	GameObject StartObject;
	GameObject EndObject;

	public GameObject IngameUI;
	public List<GameObject> StepUIList;
	public Button nextButton;

	public int currentStep = 0;

	public float timeSpent;

	bool gameStarted = false;
	bool gameEnded = false;

	public int obstacleCount = 0;

	// Use this for initialization
	void Start () {
		IngameUI.SetActive (false);
		foreach (GameObject g in StepUIList) {
			g.SetActive (false);
		}
		nextButton.onClick.AddListener (nextPressed);
	}

	// Update is called once per frame
	void Update () {
		if (gameStarted) {
			timeSpent += Time.deltaTime;
		}
		switch (currentStep) {
		case 0:
			StepUIList [currentStep].SetActive (true);
			break;
		case 1:
			StepUIList [currentStep - 1].SetActive (false);
			StepUIList [currentStep].SetActive (true);
			break;
		case 2:
			StepUIList [currentStep - 1].SetActive (false);
			StepUIList [currentStep].SetActive (true);
			break;
		case 3:
			StepUIList [currentStep - 1].SetActive (false);
			StepUIList [currentStep].SetActive (true);
			nextButton.GetComponentInChildren<Text> ().text = "LET'S RACE!";
			break;
		case 4:
			StepUIList [currentStep - 1].SetActive (false);
			StepUIList [currentStep].SetActive (true);
			break;
		case 5:
			StepUIList [currentStep - 1].SetActive (false);
			nextButton.gameObject.SetActive (false);
			break;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "start") {
			gameStarted = true;	
			IngameUI.SetActive (true);
		} else if (other.gameObject.tag == "end") {
			gameStarted = false;	
			gameEnded = true;
			IngameUI.SetActive (false);
		}
	}

	public void nextPressed() {
		if (currentStep != 3) {
			currentStep++;	
		}
		if (currentStep >= 3) {
			nextButton.gameObject.SetActive (false);
		}
	}
		
	public void addObstacle() {
		if (obstacleCount == 5) {
			currentStep = 4;
		}
		obstacleCount++;
		string baseText = "Step 4: Place up to 5 obstacles (";
		StepUIList [3].GetComponentInChildren<Text> ().text = baseText + obstacleCount + "/5)";
	}
}
