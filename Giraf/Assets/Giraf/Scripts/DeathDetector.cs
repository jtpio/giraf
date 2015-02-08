using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DeathDetector : MonoBehaviour {

	public GameObject deathText;

	AudioSource[] sources;
	AudioSource deathSound;
	AudioSource deadSound;
	
	void Start () {
		sources = GetComponents<AudioSource>();
		deathSound = sources[0];
		deadSound = sources[1];
	}
	
	void Update () {
	
	}

	public void notifyDeath(GameObject bodyPart) {
		if (GameState.state != State.DEATH) {
			GameState.Death();
			deathSound.Play();
			StartCoroutine(DeathRoutine());
		}
	}
	

	IEnumerator DeathRoutine() {
		Transform giraf = transform.Find ("Giraf");
		Component[] anims = GetComponentsInChildren<Animation>();
		Destroy(giraf.GetComponent<Bounce>());
		foreach (Animation anim in anims) {
			anim.Stop();
			Destroy(anim);
		}
		iTween.MoveTo(giraf.gameObject, iTween.Hash("position", giraf.position + Vector3.up * 20.0f, "easeType", "easeOutQuint", "time", 0.5f));
		iTween.RotateBy(giraf.gameObject, iTween.Hash("amount", new Vector3(0.5f, 0.0f, 0.0f), "easeType", "easeOutQuint", "time", 0.5f));
		yield return new WaitForSeconds(0.5f);
		iTween.MoveTo(giraf.gameObject, iTween.Hash("position", giraf.position - Vector3.up * 20.0f, "easeType", "easeOutBounce", "time", 0.5f));

		yield return new WaitForSeconds(1.0f);
		deadSound.Play();
		deathText.SetActive(true);
		GameState.GameOver();
	}

	void autoDestroy() {
		Destroy(gameObject);
	}

	void Explode () {
		List<Transform> leafs = new List<Transform>();
		FindLeaves(transform.Find ("Giraf/Bone001"), leafs);
		foreach (Transform leaf in leafs) {
			//if ( leaf.rigidbody == null) leaf.gameObject.AddComponent<Rigidbody>();
			//leaf.transform.position += (Vector3.up * 100);
			if (leaf.rigidbody != null) Destroy(leaf.rigidbody);
		}
	}

	void FindLeaves (Transform t, List<Transform> childrenList) {
		if (t.childCount == 0 && t.name != "Main Camera") {
			childrenList.Add(t);
		} else {
			foreach (Transform child in t) {
				FindLeaves(child, childrenList);
			}
		}
	}
}
