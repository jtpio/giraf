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
		if (GameState.state == State.RUN ||
			other.gameObject.layer == LayerMask.NameToLayer("Mine") ||
		    other.gameObject.layer == LayerMask.NameToLayer("GroundMine")) {
			headDeathDetector.notifyDeath(toDestroy);
		}
	}
}
