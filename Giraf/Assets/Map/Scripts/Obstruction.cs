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
   
	public AreaDescriptor areaMapper;
	public Transform explosionParticle;
	public ObstructionFallDown fallDown;

	void Start () {
		this.startingPosition = this.areaMapper.gameObject.transform.position;
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

		if (this.state == ObstructionState.Dying && !this.audio.isPlaying) {
			this.state = ObstructionState.Dead;
		}
	}

	private bool RenderState () {
		switch (this.state) {
			case ObstructionState.Falling : {	
				this.fallDown = this.gameObject.GetComponent<ObstructionFallDown>();
				this.fallDown.startingPosition = this.startingPosition;
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
				this.areaMapper.hasObstruction = false;		
				if (!this.hidden) {
					this.hidden = true;
					(transform.Find(this.mineName) as Transform).GetComponent<MeshRenderer>().enabled = false;
					(transform.Find(this.sphereName) as Transform).GetComponent<MeshRenderer>().enabled = false;	
				}
				break;
			}

			case ObstructionState.Dead : {
				Destroy(gameObject);
				break;
			}

			default:  {
				return false;
			}
		}

		return true;
	}
}
