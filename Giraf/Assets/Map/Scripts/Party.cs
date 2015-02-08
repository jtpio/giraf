using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {
	
	void Start () {
		foreach (Transform t in transform) {
			t.Rotate(0.0f, Random.Range (0.0f, 360.0f), 0.0f);
			t.GetComponent<LoopAnimation>().Delay(Random.Range(0.0f, 5.0f));
		}
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			AutoFade.LoadLevel("Game", 1.0f, 1.0f, Color.black);
		}
	}
}
