using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public Button nextButton;

	// Use this for initialization
	void Start () {
		nextButton.onClick.AddListener (nextPressed);
	}

	public void nextPressed() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
