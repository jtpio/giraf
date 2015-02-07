﻿using UnityEngine;
using System.Collections;

public class Obstruction : MonoBehaviour {

	private float currentLifeTime = 0.0f;
    private Vector3 startingPosition;
    private float currentOffsetY;

	public float totalLifeTime = 5;
    public float startingOffsetY = 600.0f;

	public AreaMapper areaMapper;

	void Start () {

        this.startingPosition = this.areaMapper.gameObject.transform.position;
        this.currentOffsetY = this.startingOffsetY;
		
        this.UpdatePosition();
	}

	// Update is called once per frame
	void Update () {
		this.currentLifeTime += Time.deltaTime;
		print (this.currentLifeTime);
		
        if(this.currentLifeTime >= this.totalLifeTime) {
			this.areaMapper.hasObstruction = false;
			Destroy(gameObject);
		} else {

            if (this.currentOffsetY > 0.0f) {
                this.currentOffsetY -= Time.deltaTime * 100.0f;

                this.UpdatePosition();
            } else if (this.currentOffsetY < 0.0f) {
                this.currentOffsetY = 0.0f;
                this.UpdatePosition();
            }

        }
	}

    void UpdatePosition() {
        this.gameObject.transform.position = new Vector3(
            this.startingPosition.x,
            this.startingPosition.y + currentOffsetY, 
            this.startingPosition.z);
    }
}
