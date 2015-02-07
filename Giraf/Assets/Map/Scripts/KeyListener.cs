using UnityEngine;
using System.Collections;
using System.Linq;

public class KeyListener : MonoBehaviour {

	public Transform obstruction;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		foreach (char c in Input.inputString) {
			this.OnKeyPress(c);
		}
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
