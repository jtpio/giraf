﻿using UnityEngine;
using System.Collections;
using System;

public class KeyListener : MonoBehaviour {
	
	public Transform cube;	

	// Use this for initialization
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
			var bomb = Instantiate(cube) as Transform;
			bomb.position = area.transform.position;
		}
	}
}
