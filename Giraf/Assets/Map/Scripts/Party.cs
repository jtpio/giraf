using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {
	
	void Start () {
		foreach (Transform t in transform) {
			t.Rotate(0.0f, Random.Range (0.0f, 360.0f), 0.0f);
			t.GetComponent<LoopAnimation>().Delay(Random.Range(0.0f, 5.0f));
			Color c = new Color(Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
			foreach (Transform subT in t) {
				if (subT.name != "Bone001") {
					subT.renderer.material.color = c;
				}
			}
		}
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			AutoFade.LoadLevel("Game", 1.0f, 1.0f, Color.black);
		} else if (Input.GetButtonDown("Fire2")) {
			AutoFade.LoadLevel("Intro", 1.0f, 1.0f, Color.black);
		}
	}
}
