using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPosition;


	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		rigidBody=GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource> ();

		rigidBody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void LaunchBall (Vector3 velocity)
	{
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
		audioSource.Play ();
	}

	public void moveStart(float nudgex){
		if (!inPlay) {
			transform.Translate ( new  Vector3 (nudgex, 0, 0));
			float xpos = transform.position.x;
			transform.position = new Vector3 (Mathf.Clamp (xpos,-50,50), transform.position.y, transform.position.y);
		}
	}

	//reset ball to start position
	public void Reset(){
		inPlay = false;
		transform.position = startPosition;
		transform.rotation = Quaternion.identity;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity=Vector3.zero;
		rigidBody.useGravity = false;
	}
}
