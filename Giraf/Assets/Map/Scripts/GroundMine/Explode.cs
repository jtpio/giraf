using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public float explosionSpeed;
	public float explosionScale;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Giraf") ||
		    other.gameObject.layer == LayerMask.NameToLayer("GroundMine")) {
			iTween.ScaleTo(gameObject, iTween.Hash("scale", transform.localScale * explosionScale, "easeType", "easeInQuad", "time", explosionSpeed, "oncomplete", "autoDestroy"));
		}
	}

	void autoDestroy() {
		Destroy(gameObject);
	}
}
