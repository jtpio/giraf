using UnityEngine;
using System.Collections;

public class Jukebox : MonoBehaviour {

	AudioSource run;
	AudioSource lost;

	AudioSource[] sources;

	void Start () {
		sources = GetComponents<AudioSource>();
		run = sources[0];
		lost = sources[1];
	}
	
	void Update () {
		switch(GameState.state) {
		case State.RUN:
			lost.Stop ();
			if (!run.isPlaying) run.Play();
			break;
		case State.LOST:
			run.Stop ();
			if (!lost.isPlaying) lost.Play();
			break;
		}
	}

	void StopAll() {
		foreach (AudioSource source in sources) {
			source.Stop ();
		}
	}
}
