using UnityEngine;
using System.Collections;

public class BigLightRotation : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
		float t = Time.time * 6.0f;
		transform.light.intensity = Mathf.Min(Mathf.Max(Mathf.Abs(Mathf.Cos(t) * Mathf.Sin(t + 0.5f)) - 0.25f, 0.2f), 0.4f) - 0.15f;
	}
}
