using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {
	
	AudioSource[] sources;
	AudioSource deathSound;
	DeathDetector headDeathDetector;

	void Start () {
		sources = GetComponents<AudioSource>();
		deathSound = sources[0];
		headDeathDetector = GameObject.Find ("GirafController").GetComponent<DeathDetector>();
	}
	
	void Update () {

	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		Debug.Log("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		Debug.Log("Their relative velocity is " + collisionInfo.relativeVelocity);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("BOOM " + gameObject.name + " and " + other.name);
		Debug.Log(other);

		headDeathDetector.notifyDeath(gameObject);
	}
}
