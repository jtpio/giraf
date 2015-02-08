using UnityEngine;
using System.Collections;

public class Translation : MonoBehaviour {
	
	public Transform end;
	public Transform endEnd;
	public Transform instructions;

	public float storyTime;
	public float pauseTime;

	void Start () {
		StartCoroutine(Routine ());
	}

	IEnumerator Routine () {
		iTween.MoveTo (gameObject, iTween.Hash("position", end, "easetype", "linear" , "time", storyTime));
		yield return new WaitForSeconds(storyTime + 2.0f);

		Camera.main.backgroundColor = Color.white;
		Camera.main.orthographicSize = 5;

		iTween.MoveTo (gameObject, iTween.Hash("position", new Vector3(instructions.position.x, transform.position.y, instructions.position.z), "time", 0.5f));
		yield return new WaitForSeconds(pauseTime);

		iTween.MoveTo (gameObject, iTween.Hash("position", endEnd, "time", 0.5f));
		NextScreen();
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			NextScreen();
		}
	}

	void NextScreen () {
		AutoFade.LoadLevel("Game", 0.5f, 0.5f, Color.black);
	}
}
