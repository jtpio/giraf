using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	public Material brown;
	public Material red;

	float phase;

	void Start () {
		phase = Random.Range(0.0f, 1.0f);
	}
	
	void Update () {
		if (Mathf.Floor(Time.time + phase) % 2 == 0) {
			renderer.material = red;
		} else {
			renderer.material = brown;
		}
	}
}
