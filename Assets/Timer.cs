using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	GameController gameController;
	Text myText;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("Player").GetComponent<GameController> ();
		myText = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = formatText();
	}

	string formatText() {
		int minutes = Mathf.FloorToInt(gameController.timeSpent / 60F);
		int seconds = Mathf.FloorToInt(gameController.timeSpent - (minutes * 60));
		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
		return niceTime;
	}
}
