using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	

	public GameObject pinSet;
	public bool ballOutOfPlay = false;

	//when count number last updated
	private float lastChangeTime;
	//private ActionMaster actionMaster = new ActionMaster();
	private pinCounter pinCounter;

	private Animator animator;

	void Start () {

		animator = FindObjectOfType<Animator> ();
		pinCounter = FindObjectOfType<pinCounter> ();
	}
	

	public void RaisePins(){
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
				pin.Raise ();
		}
	}

	public void LowerPins(){
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			pin.Lower ();
		}
	}


	public void RenewPins(){
		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position+=new Vector3(0,10,0);
	}
		

	public void PerformAction(ActionMaster.Action action){

		//act on the above actions:
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		}

		else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		}

		else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		}
		else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("dont knowhow to end game yet");
		}


	}
}
