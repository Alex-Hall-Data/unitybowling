using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pinCounter : MonoBehaviour {
	public Text standingDisplay;
	private bool ballOutOfPlay=false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ballOutOfPlay) {
			standingDisplay.color = Color.red;
			UpdateStandingCount ();
		}
		standingDisplay.text = CountStanding().ToString ();
	}


	void OnTriggerExit(Collider collider){
		if (collider.gameObject.name=="Ball"){
			ballOutOfPlay=true;
		}
	}

	public void Reset(){
		lastSettledCount = 10;
	}

	//update the last standing count and call pins settled
	void UpdateStandingCount(){
		int currentStanding = CountStanding();
		if (currentStanding != lastStandingCount) {
			standingDisplay.text = currentStanding.ToString ();
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		//wait 3 seconds after last pin fall to declare they are settled
		float settleTime=3f;
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsHaveSettled();
		}

	}

	void PinsHaveSettled(){
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;//how many fell
		Debug.Log(pinFall);
		lastSettledCount=standing;

		gameManager.Bowl (pinFall);
		//ActionMaster.Action action = actionMaster.Bowl (pinFall);//get next action for pinsetter


		lastStandingCount = -1; //indicates pins settled and ball not back in box
		ballOutOfPlay=false;
		standingDisplay.color = Color.green;
	}


	int CountStanding(){
		int totalStanding = 0;
		foreach (Pin pin in FindObjectsOfType<Pin>()){
			if (pin.IsStanding ()) {
				totalStanding += 1;
			}
		}
		//print (totalStanding);
		return totalStanding;
	}


}
