using UnityEngine;
using System.Collections;

public class EndDetector : MonoBehaviour {

	WinDetector headWinDetector;

	void Start () {
		headWinDetector = GameObject.Find ("GirafController").GetComponent<WinDetector>();
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("End")) {
			headWinDetector.notifyWin();
		}
	}
}
