using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 10;
	private float distanceToRaise=40f;
	//transform.eulerAngle
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool IsStanding(){
		float anglex = transform.eulerAngles.x;
		float anglez = transform.eulerAngles.z;

		if ((anglex < 270+ standingThreshold && anglex > 270- standingThreshold)
			|| (anglez <  standingThreshold || anglez > 360 - standingThreshold)) {
			return true;
		}
		return false;

	}


	//raise standing pins only
	public void Raise(){
			if (IsStanding ()) {
				Rigidbody rigidBody=GetComponent<Rigidbody>();

				//move pins up (note using world space rather than local space
				transform.Translate(new Vector3(0,distanceToRaise,0),Space.World);
				rigidBody.useGravity=false;
				rigidBody.angularVelocity=Vector3.zero;
				rigidBody.velocity=Vector3.zero;
			transform.rotation=Quaternion.Euler(270f,0,0);
			}
	}

	public void Lower(){
			Rigidbody rigidBody=GetComponent<Rigidbody>();
			transform.Translate(new Vector3(0,-distanceToRaise,0),Space.World);
			rigidBody.useGravity = true;
	}
}
