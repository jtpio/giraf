using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static State state;
	public float restartTimeTransition;

	void Start () {
		state = State.RUN;
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			state = State.STOP;
			AutoFade.LoadLevel("Game", restartTimeTransition / 2, restartTimeTransition / 2, Color.black);
		}
	}

	public static void GameOver() {
		state = State.LOST;
	}

	public static void GameWin() {
		state = State.WIN;
	}
}
