using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour {

	private readonly Color[] tronColors = new Color[]
	{
		new Color(0.753f, 0.302f, 0.976f),
		new Color(0.397f, 0.910f, 0.122f),
		new Color(0.878f, 0.890f, 0.890f),
		new Color(1f, 0.902f, 0.302f),
		new Color(0.937f, 0.580f, 0.231f),
	};

	// Use this for initialization
	void Start () {
		int index = Random.Range (0, tronColors.Length);
		if (GetComponent<Renderer> () != null) {
			GetComponent<Renderer> ().material.SetColor ("_MKGlowColor", tronColors [index]);
			GetComponent<Renderer> ().material.SetColor ("_MKGlowTexColor", tronColors [index]);
		} else {
			foreach (Renderer renderer in GetComponentsInChildren<Renderer>()) {
				renderer.material.SetColor ("_MKGlowColor", tronColors [index]);
				renderer.material.SetColor ("_MKGlowTexColor", tronColors [index]);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
