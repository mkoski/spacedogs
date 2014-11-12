using UnityEngine;
using System.Collections;

public class SpaceshipSteering : MonoBehaviour {

	public float maxTurnRate = 0f;
	public float turnSensitivity = 0f;
	private Transform _transform;
	private Vector3 turnRate = Vector3.zero;
	private float inputX = 0f;
	private float inputY = 0f;

	void Start() {
		_transform = transform; // Cache
	}

	void LateUpdate () {
		SteerCheck ();
		_transform.Rotate (turnRate * Time.deltaTime, Space.Self); // Rotate spaceship
	} 

	void SteerCheck() {
		if (this == null) { return;}
		inputX = 0f;
		inputY = 0f;
		inputX +=  Input.GetAxis("Vertical") * turnSensitivity * Time.deltaTime;	
		inputY +=  Input.GetAxis("Horizontal") * turnSensitivity * Time.deltaTime;
		SetTurnRate (inputX, inputY, 0);	
	}
	
	private void SetTurnRate (float x, float y, float z) {
		turnRate.x = Mathf.Clamp (x, -maxTurnRate, maxTurnRate);
		turnRate.y = Mathf.Clamp (y, -maxTurnRate, maxTurnRate);
		turnRate.z = Mathf.Clamp (z, -maxTurnRate, maxTurnRate);
	}
}
