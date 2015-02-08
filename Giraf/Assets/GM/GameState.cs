using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static State state;

	void Start () {
		state = State.PAUSE;
	}
	
	void Update () {
	
	}

	public static void GameOver() {
		state = State.LOST;
	}
}
