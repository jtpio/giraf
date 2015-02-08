using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float forwardSpeed;
	public float turnSpeed;
	public float tiltSpeed;
	public float tiltAngleRange;

	CharacterController controller;
	float minTiltAngle, maxTiltAngle;
	Transform neck;

	void Start () {
		neck = GameObject.Find("Giraf_neck").transform;
		minTiltAngle = neck.eulerAngles.x - tiltAngleRange / 2;
		maxTiltAngle = neck.eulerAngles.x + tiltAngleRange / 2;
		controller = GetComponent<CharacterController>();
		StartCoroutine("PreAnimation");
	}

	IEnumerator PreAnimation () {
		yield return new WaitForSeconds(2.0f);
		iTween.RotateBy(gameObject, iTween.Hash("amount", new Vector3(0.0f, 0.5f, 0.0f), "easeType", "easeOutQuint", "time", 0.5f));
		yield return new WaitForSeconds(0.5f);
		GameState.Run ();
	}
	
	void Update () {

		if (GameState.state != State.RUN) return;

		if (Input.GetButtonDown("Fire2")) {
			forwardSpeed += 10.0f;
		}

		float rawLeftAxis = Input.GetAxis("LeftStickX");
		float rawRightAxisX = Input.GetAxis("RightStickX");
		//float rawRightAxisY = Input.GetAxis("RightStickY");

		if (Mathf.Abs(rawLeftAxis) < 0.4f) rawLeftAxis = 0;
		if (Mathf.Abs(rawRightAxisX) < 0.4f) rawRightAxisX = 0;
		//if (Mathf.Abs(rawRightAxisY) < 0.6f) rawRightAxisY = 0;

		float turn = rawLeftAxis * Time.deltaTime * turnSpeed;
		float tiltX = rawRightAxisX * Time.deltaTime * tiltSpeed;
		//float tiltY = rawRightAxisY * Time.deltaTime * tiltSpeed;
		
		transform.rotation *= Quaternion.AngleAxis(turn, Vector3.up);
		controller.Move(transform.forward * Time.deltaTime * forwardSpeed);

		if (neck == null) return;

		Vector3 currentEuler = neck.eulerAngles;
		if (neck.eulerAngles.x >= minTiltAngle && neck.eulerAngles.x <= maxTiltAngle) {
			neck.Rotate(tiltX, 0.0f, 0.0f);
		} else if (tiltAngleRange < 360) {
			neck.eulerAngles = new Vector3(Mathf.Lerp(currentEuler.x, Mathf.Clamp(currentEuler.x, minTiltAngle, maxTiltAngle), Time.deltaTime * 100), currentEuler.y, currentEuler.z);
		}
	
		Debug.DrawLine(transform.position, transform.position + transform.forward, Color.green);
		Debug.DrawLine(neck.position, neck.position - neck.right, Color.red);
	
	}

}
