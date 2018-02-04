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
	public Text penaltyText;
	public GameObject gameoverUI;
	public GameObject gameoverCollisionText;
	public GameObject gameoverTimeText;

	public int currentStep = 0;

	public float timeSpent;

	bool gameActivated = false;
	bool gameStarted = false;
	bool gameEnded = false;

	int collisionCount = 0;

	public int obstacleCount = 0;

	// Use this for initialization
	void Start () {
		IngameUI.SetActive (false);
		gameoverUI.SetActive (false);
		penaltyText.gameObject.SetActive (false);
		nextButton.onClick.AddListener (nextPressed);
		deactivateUI ();
		handleUI ();
	}

	void deactivateUI() {
		foreach (GameObject g in StepUIList) {
			g.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (gameStarted) {
			timeSpent += Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "start" && gameActivated && !gameEnded) {
			gameStarted = true;	
			IngameUI.SetActive (true);
		} else if (other.gameObject.tag == "end" && gameStarted) {
			gameStarted = false;	
			gameEnded = true;
			IngameUI.SetActive (false);
			gameoverUI.SetActive (true);
			gameoverCollisionText.GetComponent<Text> ().text = "Collisions: " + collisionCount;
			gameoverTimeText.GetComponent<Text> ().text = "Time: " + timeSpent;
		} else if (other.gameObject.tag == "obstacle" && gameStarted) {
			timeSpent += 5;
			collisionCount++;
			StartCoroutine(showPenaltyText());
		}
	}

	public void nextPressed() {
		if (currentStep != 3) {
			currentStep++;	
		} else {
			nextButton.gameObject.SetActive (false);
			deactivateUI ();
			gameActivated = true;
		}
		if (currentStep >= 4) { //Just go to the game
			if (currentStep >= 4) {
				nextButton.gameObject.SetActive (false);
				StepUIList [currentStep].SetActive (false);
				gameActivated = true;
			}
		}

		if (!gameActivated) {
			handleUI ();
		}
	}

	void handleUI() {

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
		case 4: //This is when you placed all 5 obstacles
			StepUIList [currentStep - 1].SetActive (false);
			StepUIList [currentStep].SetActive (true);
			break;
		case 5: // The game started 
			StepUIList [currentStep - 1].SetActive (false);
			nextButton.gameObject.SetActive (false);
			break;
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

	IEnumerator showPenaltyText()
	{
		penaltyText.gameObject.SetActive (true);
		yield return new WaitForSeconds(1.5f);
		penaltyText.gameObject.SetActive (false);
	}
}
