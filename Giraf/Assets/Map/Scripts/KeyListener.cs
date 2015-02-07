using UnityEngine;
using System.Collections;
using System.Linq;

public class KeyListener: MonoBehaviour {

	public delegate void OnKeyPress(char c);

	// attach event to a key press
	public static void AttachKeyPressEvent (OnKeyPress onKeyPress) {
		foreach (char c in Input.inputString) {
			onKeyPress(c);
		}
	}
}
