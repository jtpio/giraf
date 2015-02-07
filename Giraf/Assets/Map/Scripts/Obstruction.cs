using UnityEngine;
using System.Collections;
using System.Linq;

public class Obstruction : MonoBehaviour {

	private float currentLifeTime = 0.0f;
    private Vector3 startingPosition;
    private float currentOffsetY;
	private bool explode = false;
	private string mineName = "Mine";
	private string sphereName = "Sphere001";

	public float totalLifeTime = 5;
    public float startingOffsetY = 600.0f;
	public AreaDescriptor areaMapper;
	public Transform explosionParticle;

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

			if (!this.explode) {
				var explosionParticle = Instantiate(this.explosionParticle) as Transform;
				explosionParticle.position = (transform.Find(this.mineName)).position;

				this.explode = true;
				this.audio.Play ();
				(transform.Find(this.mineName) as Transform).GetComponent<MeshRenderer>().enabled = false;
				(transform.Find(this.sphereName) as Transform).GetComponent<MeshRenderer>().enabled = false;

			} else if (!audio.isPlaying) {
				Destroy(gameObject);
			}
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
