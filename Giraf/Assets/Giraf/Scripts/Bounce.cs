using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
	
	public Vector3 direction;
	public float amplitude;
	public float speed;
	
	float phase;

	void Start () {
		if (direction.magnitude == 0) {
			direction = new Vector3(0.0f, 1.0f, 0.0f);
		}
		if (speed == 0) {
			speed = 1;
		}
		phase = Random.Range(0.0f, Mathf.PI);
	}
	
	void Update () {
		transform.position = transform.position + direction * amplitude * Mathf.Sin(speed * Time.time + phase);
	}
}
