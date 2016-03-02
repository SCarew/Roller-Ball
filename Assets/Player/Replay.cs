using UnityEngine;
using System.Collections;

public class Replay : MonoBehaviour {

	private const int bufferFrames = 100;
	private MyKeyframe[] keyFrames = new MyKeyframe[bufferFrames];
	private Rigidbody rb;
	private GameManager gm;

	void Start () {
		rb = GetComponent<Rigidbody>();
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {
		if (gm.isRecording) {
			Record ();  
		} else {
			Playback();
		}
	}

	void Playback() {
		rb.isKinematic = true;
		int frame = Time.frameCount % bufferFrames; // % = modulus operator
		transform.position = keyFrames[frame].myPosition;
		transform.rotation = keyFrames[frame].myRotation;
	}

	void Record () {
		rb.isKinematic = false;
		int frame = Time.frameCount % bufferFrames; 
		float time = Time.time;
		keyFrames [frame] = new MyKeyframe (time, transform.position, transform.rotation);
	}
}

/// <summary>
/// A structure for storing time, position, and rotation.
/// </summary>
public struct MyKeyframe {
	public float myTime;
	public Vector3 myPosition;
	public Quaternion myRotation;

	public MyKeyframe(float time, Vector3 position, Quaternion rotation) {  //constructor
		myTime = time;
		myPosition = position;
		myRotation = rotation;
	}
}
