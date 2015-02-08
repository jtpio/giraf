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
		AutoFade.LoadLevel("Finish", 0.5f, 0.5f, Color.white);
	}
}
