using UnityEngine;
using System.Collections;

public class SelfieStick : MonoBehaviour {

	public float panSpeed = 10f;
	private Transform rollerball;
	private float original_y;
	private Vector3 armRotation;

	void Start () {
		rollerball = GameObject.FindWithTag("Player").gameObject.transform;
		original_y = gameObject.transform.position.y - rollerball.position.y;
		armRotation = transform.rotation.eulerAngles; //eulerAngles converts quaternion to vector3
	}
	
	void Update () {
		armRotation.y += Input.GetAxis("RHorizontal") * panSpeed;
		armRotation.z += Input.GetAxis("RVertical") * panSpeed;
		transform.rotation = Quaternion.Euler(armRotation); //Euler converts vector3 to quaternion
		/*float ry = Input.GetAxis("RHorizontal") * panSpeed;
		float rz = Input.GetAxis("RVertical") * panSpeed;
		transform.RotateAround(rollerball.transform.position, Vector3.up, ry);
		transform.RotateAround(rollerball.transform.position, Vector3.forward, rz);
		*/

		float y = rollerball.position.y + original_y;
		float z = rollerball.position.z;
		transform.position = new Vector3(transform.position.x, y, z);
	}

}
