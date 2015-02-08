using UnityEngine;
using System.Collections;

public class SpotlightMove : MonoBehaviour {
	
	public float speed;
	public float distance;
	public float movementInDirectionTime = 3.0f;

	
	public Vector3 startingPosition;
	private float limit = 10.0f;

	// Use this for initialization
	void Start () {
		this.startingPosition = this.gameObject.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {

		if (this.gameObject.transform.position.z < this.limit) {
			this.limit = 5;
			Vector3 positionA = new Vector3(this.gameObject.transform.position.x,
			                                this.gameObject.transform.position.y,
			                                this.gameObject.transform.position.z + 50);
			
			transform.position = Vector3.Lerp(transform.position, positionA, 0.3f * Time.deltaTime);
		}

		else {
			this.limit = -5;
			Vector3 positionB = new Vector3(this.gameObject.transform.position.x,
			                                this.gameObject.transform.position.y,
			                                this.gameObject.transform.position.z - 50);
			
			transform.position = Vector3.Lerp(transform.position, positionB, 0.3f * Time.deltaTime);
		}
	}
}
