using UnityEngine;
using System.Collections;
using System.Linq;

public class Obstruction : MonoBehaviour {

	private float currentLifeTime = 0.0f;
    private Vector3 startingPosition;
    private float currentOffsetY;
	private bool hidden = false;
	private string mineName = "Mine";
	private string sphereName = "Sphere001";
	private ExplodeParticle particle;
	private ObstructionState state = ObstructionState.Falling;

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
		this.UpdateState();
		this.RenderState();
	}

	private void UpdateState () {
		if (this.currentLifeTime + 0.2 >= this.totalLifeTime && this.state == ObstructionState.Falling) {
			this.state = ObstructionState.Exploding;
		}
		
		if(this.currentLifeTime >= this.totalLifeTime && this.state == ObstructionState.Dying) {
			this.state = ObstructionState.Dead;
		} 
	}

	private bool RenderState () {
		switch (this.state) {
			case ObstructionState.Falling : {		
				if (this.currentOffsetY > 10.0f) {
					this.currentOffsetY -= Time.deltaTime * 100.0f;
					
					this.UpdatePosition();
				} else if (this.currentOffsetY < 10.0f) {
					this.currentOffsetY = 10.0f;
					this.UpdatePosition();
				}

				break;
			}

			case ObstructionState.Exploding : {
				this.explosionParticle = Instantiate(this.explosionParticle) as Transform;
				explosionParticle.position = (transform.Find(this.mineName)).position;

				if (!audio.isPlaying) {
					this.audio.Play ();
				}

			    this.state = ObstructionState.Dying;

				break;
			}

			case ObstructionState.Dying : {
				break;
			}

			case ObstructionState.Dead : {
				this.areaMapper.hasObstruction = false;
				if (!this.hidden) {
					this.hidden = true;
					(transform.Find(this.mineName) as Transform).GetComponent<MeshRenderer>().enabled = false;
					(transform.Find(this.sphereName) as Transform).GetComponent<MeshRenderer>().enabled = false;
					
				} else if (!audio.isPlaying) {
					Destroy(gameObject);
				}

				break;
			}

			default:  {
				return false;
			}
		}

		return true;
	}

    void UpdatePosition() {
        this.gameObject.transform.position = new Vector3(
            this.startingPosition.x,
            this.startingPosition.y + currentOffsetY, 
            this.startingPosition.z);
    }
}
