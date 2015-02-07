using UnityEngine;
using System.Collections;
using System.Linq;

public class SceneManager : MonoBehaviour {

	public Transform obstruction;

	// Update is called once per frame
	void Update () {
		KeyListener.AttachKeyPressEvent(this.OnKeyPress);
	}

	private void OnKeyPress(char c) {
		var area = GameObject.Find(c.ToString().ToUpper());
		if (area != null) {

			var areaMapper = area.GetComponent<AreaDescriptor>();

			if (!areaMapper.hasObstruction) {
				var bomb = Instantiate(obstruction) as Transform;
				var obstructionScript = bomb.GetComponent<Obstruction>();
				obstructionScript.areaMapper = areaMapper;
				areaMapper.hasObstruction = true;
			}
		}
	}
}
