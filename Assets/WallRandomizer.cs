using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRandomizer : MonoBehaviour {

	public float startX;
	public float startY;
	public float startZ;
	public float maxX;
	public float maxY;
	public float maxZ;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(Random.value * maxX + startX, Random.value * maxY + startY, Random.value * maxZ + startZ);
		transform.Rotate(new Vector3(0, Random.value * 360, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
