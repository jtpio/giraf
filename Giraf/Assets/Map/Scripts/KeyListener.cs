using UnityEngine;
using System.Collections;
using System.Linq;

public class KeyListener : MonoBehaviour {
	
	public Transform cube;

	// Update is called once per frame
	void Update () {
		foreach (char c in Input.inputString) {
			this.OnKeyPress(c);
		}
	}

	private void OnKeyPress(char c) {
		var area = GameObject.Find(c.ToString().ToUpper());
		if (area != null) {
			var areaMapper = area.GetComponent<AreaMapper>();

			if (areaMapper.hasObstruction == false) {
				var bomb = Instantiate(cube) as Transform;

				var obstruction = bomb.GetComponent<Obstruction>();
				obstruction.areaMapper = areaMapper;

				bomb.position = area.transform.position;
				areaMapper.hasObstruction = true;
			}
		}
	}
}
