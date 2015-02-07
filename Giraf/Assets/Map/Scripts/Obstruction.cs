using UnityEngine;
using System.Collections;

public class Obstruction : MonoBehaviour {

	private float currentLifeTime = 0.0f;	

	public float totalLifeTime = 5;

	public AreaMapper areaMapper;

	// Update is called once per frame
	void Update () {
		this.currentLifeTime += Time.deltaTime;
		print (this.currentLifeTime);
		if(this.currentLifeTime >= this.totalLifeTime) {
			this.areaMapper.hasObstruction = false;
			Destroy(gameObject);
		}
	}
}
