using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

	public float maxTurnRate = 0f;
	public float turnSensitivity = 0f;
	private Transform _transform;
	private Vector3 turnRate = Vector3.zero;
	private float rotationZ = 0f;
	private Vector3 center = Vector3.zero;
	
	void Start() {
		_transform = transform; // Cache
	}

	void Update () {
		SteerCheck ();
		_transform.Rotate (turnRate * Time.deltaTime, Space.Self);
	}
	
	void SteerCheck() {
		if (this == null) { return;}
		Debug.Log (rotationZ);
		//rotationZ = Mathf.Lerp (rotationZ, 0f, 0.2f);
		rotationZ = 0f;
		rotationZ +=  Input.GetAxis("Horizontal") * 3000 * Time.deltaTime;
		rotationZ = Mathf.Clamp (rotationZ, -45, 45);
		_transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
	}
}
