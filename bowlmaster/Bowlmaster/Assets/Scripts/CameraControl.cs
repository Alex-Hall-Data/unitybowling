using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Ball ball;

	//offset between ball and camera
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position-ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//follow if in front of head pin
		if (ball.transform.position.z < 1829) {
			transform.position = ball.transform.position + offset;
		}
	}
}
