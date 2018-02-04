using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHover : MonoBehaviour {
	
	//adjust this to change speed
	float speed = 2f;
	//adjust this to change how high it goes
	float height = 0.5f;

	void Update() {
		//get the objects current position and put it in a variable so we can access it later with less code
		Vector3 pos = transform.localPosition;
		//calculate what the new Y position will be
		float newY = Mathf.Sin(Time.time * speed);
		//set the object's Y to the new calculated Y
		transform.localPosition = new Vector3(pos.x, newY  * height + 5f, pos.z);
	}
}
