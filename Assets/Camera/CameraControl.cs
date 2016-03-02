using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Transform rollerball;
	private float original_y;

	void Start () {
		rollerball = GameObject.FindWithTag("Player").gameObject.transform;
		original_y = Camera.main.transform.position.y;
	}
	
	void LateUpdate () {
		float y = rollerball.position.y + original_y;
		float z = rollerball.position.z;
		Camera.main.transform.position = new Vector3(transform.position.x, y, z);
	}
}
