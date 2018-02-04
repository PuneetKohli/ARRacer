using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print ("hello world");
	}

	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
	}
}
