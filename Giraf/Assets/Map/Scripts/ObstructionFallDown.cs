using UnityEngine;
using System.Collections;

public class ObstructionFallDown : MonoBehaviour {

	public Vector3 startingPosition;
	private float currentOffsetY;

	public float startingOffsetY = 200.0f;

	void Start () {
		this.currentOffsetY = this.startingOffsetY;
		this.UpdatePosition();
	}
	
	void Update () {
		if (this.currentOffsetY > 10.0f) {
			this.currentOffsetY -= Time.deltaTime * 100.0f;
			
			this.UpdatePosition();
		} else if (this.currentOffsetY < 10.0f) {
			this.currentOffsetY = 10.0f;
			this.UpdatePosition();
		}
	}
	
	void UpdatePosition() {
		this.gameObject.transform.position = new Vector3(
			this.startingPosition.x,
			this.startingPosition.y + currentOffsetY, 
			this.startingPosition.z);
	}
}
