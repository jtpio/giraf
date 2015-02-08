using UnityEngine;
using System.Collections;

public class BigLightRotation : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
		transform.Rotate(new Vector3(0.0f, 30.0f * Time.deltaTime, 0.0f));
	}
}
