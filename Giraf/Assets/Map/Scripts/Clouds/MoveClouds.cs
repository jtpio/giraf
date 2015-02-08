using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour {

	public float speed;

	void Start () {
	
	}
	
	void Update () {
		transform.position += new Vector3(0.0f, 0.0f, 1.0f) * speed * Time.deltaTime;
	}
}
