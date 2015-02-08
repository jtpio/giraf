using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float forwardSpeed;
	public float turnSpeed;
	public float tiltSpeed;
	public float tiltAngleRange;

	float minTiltAngle, maxTiltAngle;
	Transform neck;

	void Start () {
		neck = transform.Find("Giraf/Giraf_neck");
		minTiltAngle = neck.eulerAngles.x - tiltAngleRange / 2;
		maxTiltAngle = neck.eulerAngles.x + tiltAngleRange / 2;
	}
	
	void Update () {

		if (GameState.state == State.LOST) return;

		float rawLeftAxis = Input.GetAxis("LeftStickX");
		float rawRightAxisX = Input.GetAxis("RightStickX");
		float rawRightAxisY = Input.GetAxis("RightStickY");

		if (Mathf.Abs(rawLeftAxis) < 0.4f) rawLeftAxis = 0;
		if (Mathf.Abs(rawRightAxisX) < 0.4f) rawRightAxisX = 0;
		if (Mathf.Abs(rawRightAxisY) < 0.6f) rawRightAxisY = 0;

		float turn = rawLeftAxis * Time.deltaTime * turnSpeed;
		float tiltX = rawRightAxisX * Time.deltaTime * tiltSpeed;
		float tiltY = rawRightAxisY * Time.deltaTime * tiltSpeed;
		
		transform.rotation *= Quaternion.AngleAxis(turn, Vector3.up);
		transform.position += transform.forward * Time.deltaTime * forwardSpeed;

		if (neck == null) return;

		Vector3 currentEuler = neck.eulerAngles;
		//neck.localRotation = Quaternion.AngleAxis(tiltX, neck.localRotation * (-transform.right));
		//neck.rotation = Quaternion.AngleAxis(tiltX, transform.forward) * transform.rotation;
		if (neck.eulerAngles.x >= minTiltAngle && neck.eulerAngles.x <= maxTiltAngle) {
			neck.Rotate(tiltX, 0.0f, 0.0f);
		} else if (tiltAngleRange < 360) {
			neck.eulerAngles = new Vector3(Mathf.Lerp(currentEuler.x, Mathf.Clamp(currentEuler.x, minTiltAngle, maxTiltAngle), Time.deltaTime * 100), currentEuler.y, currentEuler.z);
		}
	
		//neck.eulerAngles = new Vector3(Mathf.Clamp(neck.eulerAngles.x + tiltX, maxTiltAngle, minTiltAngle), neck.eulerAngles.y, neck.eulerAngles.z);
		//Debug.Log (neck.eulerAngles);
		Debug.DrawLine(transform.position, transform.position + transform.forward, Color.green);
		Debug.DrawLine(neck.position, neck.position - neck.right, Color.red);
		
		//controller.Move(transform.forward * Time.deltaTime * forwardSpeed);
	}

}
