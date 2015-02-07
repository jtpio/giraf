using UnityEngine;
using System.Collections;
using System.Linq;

public class Obstruction : MonoBehaviour {

	private float currentLifeTime;
    private float currentOffsetY;
	private string mineName = "Mine";
	private ObstructionState state;

	public float totalLifeTime = 5;
   
	public AreaDescriptor areaMapper;
	public ExplodeParticle explosionParticle;
	private ObstructionFallDown fallDown;
	
	// Update is called once per frame
	void Update () {
		this.currentLifeTime += Time.deltaTime;
		this.RenderState();
	}

	private void RenderState () {
		switch (this.state) {
			case ObstructionState.Falling : {	
				this.fallDown = this.gameObject.GetComponent<ObstructionFallDown>();
				this.fallDown.startingPosition = this.areaMapper.gameObject.transform.position;

				if (this.currentLifeTime + 0.2 >= this.totalLifeTime) {
					this.state = ObstructionState.Exploding;
				}
				break;
			}

			case ObstructionState.Exploding : {
				this.explosionParticle = Instantiate(this.explosionParticle) as ExplodeParticle;
				this.explosionParticle.transform.position = (transform.Find(this.mineName)).position;
				this.explosionParticle.PlaySound();
			    this.state = ObstructionState.Dying;

				break;
			}

			case ObstructionState.Dying : {
				this.areaMapper.hasObstruction = false;		

				foreach (Transform child in transform) {
					child.GetComponent<MeshRenderer>().enabled = false;
				}	

				this.state = ObstructionState.Dead;

				break;
			}

			case ObstructionState.Dead : {
				Destroy(gameObject);
				break;
			}

			default:  {
				break;
			}
		}
	}
}
