using UnityEngine;
using System.Collections;

public class ObstructionFallDown : MonoBehaviour {

	public Vector3 startingPosition;
	private float currentOffsetY;

	public float startingOffsetY = 200.0f;
	public float finallOffsetY = 10.0f;
	public float animationSpeed = 100.0f;

	void Start () {
		this.audio.Play();
		this.currentOffsetY = this.startingOffsetY;
		this.UpdatePosition();
	}
	
	void Update () {
		if (this.currentOffsetY > this.finallOffsetY) {
			this.currentOffsetY -= Time.deltaTime * this.animationSpeed;
			
			this.UpdatePosition();
		} else if (this.currentOffsetY < this.finallOffsetY) {
			this.currentOffsetY = this.finallOffsetY;
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
