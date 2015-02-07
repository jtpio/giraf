using UnityEngine;
using System.Collections;
using System.Linq;

public class KeyListener : MonoBehaviour {

	private AreaManager areaManager;

	public Transform obstruction;

	void Start() {
		this.areaManager = new AreaManager ();
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
			this.areaManager.activateBomb(area, obstruction);
		}
	}
}
