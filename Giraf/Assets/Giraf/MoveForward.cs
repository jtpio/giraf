using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
	
	public float turnSpeed;
	public float tiltSpeed;
	public float tiltAngleRange;

	float minTiltAngle, maxTiltAngle;
	CharacterController controller;
	Transform neck;

	void Start () {
		controller = GetComponent<CharacterController>();
		neck = transform.Find("Giraf/Giraf_neck");
		minTiltAngle = neck.eulerAngles.x - tiltAngleRange / 2;
		maxTiltAngle = neck.eulerAngles.x + tiltAngleRange / 2;
	}
	
	void Update () {
		float rawLeftAxis = Input.GetAxis("LeftStickX");
		float rawRightAxisX = Input.GetAxis("RightStickX");
		float rawRightAxisY = Input.GetAxis("RightStickY");

		if (Mathf.Abs(rawLeftAxis) < 0.4f) rawLeftAxis = 0;
		if (Mathf.Abs(rawRightAxisX) < 0.4f) rawRightAxisX = 0;
		if (Mathf.Abs(rawRightAxisY) < 0.6f) rawRightAxisY = 0;

		float turn = rawLeftAxis * Time.deltaTime * turnSpeed;
		float tiltX = rawRightAxisX * Time.deltaTime * tiltSpeed;
		float tiltY = rawRightAxisY * Time.deltaTime * tiltSpeed;


		Vector3 currentEuler = neck.eulerAngles;
		//neck.localRotation = Quaternion.AngleAxis(tiltX, neck.localRotation * (-transform.right));
		//neck.rotation = Quaternion.AngleAxis(tiltX, transform.forward) * transform.rotation;
		if (neck.eulerAngles.x >= minTiltAngle && neck.eulerAngles.x <= maxTiltAngle) {
			neck.Rotate(tiltX, 0.0f, 0.0f);
		} else {
			neck.eulerAngles = new Vector3(Mathf.Clamp(currentEuler.x, minTiltAngle, maxTiltAngle), currentEuler.y, currentEuler.z);
		}
	
		//neck.eulerAngles = new Vector3(Mathf.Clamp(neck.eulerAngles.x + tiltX, maxTiltAngle, minTiltAngle), neck.eulerAngles.y, neck.eulerAngles.z);
		Debug.Log ("euler angles: " + neck.eulerAngles);
		Debug.Log (minTiltAngle + ", " + maxTiltAngle);
		//Debug.Log (neck.eulerAngles);
		Debug.DrawLine(transform.position, transform.position + transform.forward, Color.green);
		Debug.DrawLine(neck.position, neck.position - neck.right, Color.red);

		transform.rotation *= Quaternion.AngleAxis(turn, Vector3.up);
		controller.Move(transform.forward * Time.deltaTime);
	}

}
