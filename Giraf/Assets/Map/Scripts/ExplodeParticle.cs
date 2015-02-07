using UnityEngine;
using System.Collections;

public class ExplodeParticle : MonoBehaviour {

	private float currentLifeTime = 0.0f;

	public float totalLifeTime = 5;
	
	// Update is called once per frame
	void Update () {
		this.currentLifeTime += Time.deltaTime;

		if (this.currentLifeTime >= this.totalLifeTime) {
			Destroy(this.gameObject);
		}
	}
}
