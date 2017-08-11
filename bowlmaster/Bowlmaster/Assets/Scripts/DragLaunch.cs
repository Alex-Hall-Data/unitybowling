using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]

public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 mouseStartPos;
	private Vector3 mouseEndPos;
	private float startTime;
	private float endTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}
	
	public void DragStart(){
		if (!ball.inPlay) {
			//capture time and position of drag start
			mouseStartPos = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd(){
		//launch the ball
		if (!ball.inPlay) {
			mouseEndPos = Input.mousePosition;
			endTime = Time.time;
			float dragDuration = endTime - startTime;
			float xVelocity = (mouseEndPos.x - mouseStartPos.x) / dragDuration;
			float zVelocity = (mouseEndPos.y - mouseStartPos.y) / dragDuration;
			ball.LaunchBall (new Vector3 (xVelocity, 0, zVelocity));
		}
	}


}
