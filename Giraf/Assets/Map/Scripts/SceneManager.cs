using UnityEngine;
using System.Collections;
using System.Linq;

public class SceneManager : MonoBehaviour {

	public Transform obstruction;

	public GameMode gamemode;

	// Update is called once per frame
	void Start () {
		if (this.gamemode == GameMode.SinglePlayer) {
			InvokeRepeating("ThrowBomb", 2.0f, 2.0f);
		}
	}

	void Update() {
		if (this.gamemode == GameMode.Multiplayer) {
			KeyListener.AttachKeyPressEvent(this.OnKeyPress);
		}
	}

	private void ThrowBomb() {		
		char c = (char)('a' + Random.Range(0, 26));
		var randomArea = GameObject.Find(c.ToString().ToUpper());
		this.RenderBomb(randomArea);
	}

	private void OnKeyPress(char c) {
		var area = GameObject.Find(c.ToString().ToUpper());
		if (area != null) {

			this.RenderBomb(area);

		}
	}
	
	private void RenderBomb (GameObject area) {
		var areaMapper = area.GetComponent<AreaDescriptor> ();
		if (!areaMapper.hasObstruction && GameObject.FindGameObjectsWithTag("FlyingMine").Length < 8) {
			var bomb = Instantiate (obstruction) as Transform;
			var obstructionScript = bomb.GetComponent<Obstruction> ();
			obstructionScript.areaMapper = areaMapper;
			areaMapper.hasObstruction = true;
		}
	}
}
