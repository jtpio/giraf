using UnityEngine;
using System.Collections;

public class WinDetector : MonoBehaviour {

	public GameObject winText;

	void Start () {
	}
	
	void Update () {
	
	}

	public void notifyWin () {
		GameState.GameWin();
		winText.SetActive(true);
	}
}
