using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {
	
	DeathDetector headDeathDetector;

	GameObject toDestroy;

	void Start () {
		headDeathDetector = GameObject.Find ("GirafController").GetComponent<DeathDetector>();
		toDestroy = GameObject.Find ("Giraf");
	}
	
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("COLLISION GROUND MINE");
		if (other.gameObject.layer == LayerMask.NameToLayer("Mine") ||
		    other.gameObject.layer == LayerMask.NameToLayer("GroundMine")) {
			headDeathDetector.notifyDeath(toDestroy);
		}
	}
}
