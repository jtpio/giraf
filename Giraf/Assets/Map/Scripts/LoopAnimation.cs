using UnityEngine;
using System.Collections;

public class LoopAnimation : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void Delay(float delay) {
		StartCoroutine(StartAnimation(delay));
	}

	IEnumerator StartAnimation (float delay) {
		yield return new WaitForSeconds(delay);
		GetComponent<Animation>().Play();
	}

}
