using UnityEngine;
using System.Collections;

public class DeathDetector : MonoBehaviour {

	public GameObject deathText;

	AudioSource[] sources;
	AudioSource deathSound;

	void Start () {
		sources = GetComponents<AudioSource>();
		deathSound = sources[1];
	}
	
	void Update () {
	
	}

	public void notifyDeath(GameObject bodyPart) {
		deathSound.Play();
		GameState.GameOver();
		deathText.SetActive(true);
		
		Destroy(bodyPart);
	}
}
