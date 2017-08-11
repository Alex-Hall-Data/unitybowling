using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	//destroy pins if they leave box
	void OnTriggerExit(Collider collider){
		GameObject thingHit = collider.gameObject;
		//if pin leaves playbox - need to look in parent since pin collider is in a child object for each pin
		if (thingHit.GetComponent<Pin> ()) {
			Destroy (thingHit);
		}
	}
}
