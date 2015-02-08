using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {
	
	DeathDetector headDeathDetector;

	void Start () {
		headDeathDetector = GameObject.Find ("GirafController").GetComponent<DeathDetector>();
	}
	
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Mine")) {
			headDeathDetector.notifyDeath(gameObject);
		}
	}
}
