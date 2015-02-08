using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
	public static State state;
	public float restartTimeTransition;

	void Start () {
		state = State.PAUSE;
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			state = State.STOP;
			AutoFade.LoadLevel("Game", restartTimeTransition / 2, restartTimeTransition / 2, Color.black);
		}
	}

	public static void Run() {
		state = State.RUN;
	}

	public static void Death() {
		state = State.DEATH;
	}

	public static void GameOver() {
		state = State.LOST;
	}

	public static void GameWin() {
		state = State.WIN;
	}

}
