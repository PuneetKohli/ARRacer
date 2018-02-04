using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAlternateScript : MonoBehaviour {

	//adjust this to change speed
	float speed = 2f;

	// Update is called once per frame
	void Update () {
		//get the objects current position and put it in a variable so we can access it later with less code
		Vector3 scale = transform.localScale;
		//calculate what the new Y position will be
		float newScale = Mathf.Sin(Time.time * speed / 40);
		//set the object's Y to the new calculated Y
		transform.localScale = new Vector3(1.0f + newScale, 1.0f + newScale, 1.0f + newScale);
	}
}
