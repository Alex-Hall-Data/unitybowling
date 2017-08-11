using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action{Tidy,Reset,EndTurn,EndGame};
	private int[] bowls = new int[21]; //scores for each bowl
	private int bowl=1;

	//takes list of previous pinfalls and returns next action
	//static so can be called directly from the class
	public static Action NextAction(List<int> pinFalls){
		ActionMaster am = new ActionMaster ();
		Action currentAction = new Action ();
		foreach (int pinFall in pinFalls) {
			currentAction = am.Bowl (pinFall);
		}
		return currentAction;
	}
		
	private Action Bowl(int pins){
		if(pins<0 || pins>10){
			throw new UnityException ("Pin count out of range");
		}

		bowls [bowl - 1] = pins;

		//if endgame
		if (bowl == 21) {
			return Action.EndGame;
		}

		//if endgame
		if (bowl == 20 && !Bowl21Awarded()) {
			return Action.EndGame;
		}
			
		//if strike then less than ten knocked over in last frame
		if (bowl == 20 && Bowl21Awarded () && bowls [19 - 1] == 10 &&bowls[19]<10) {
			return Action.Tidy;
		}

		//if strike on last frame
		if(bowl>=19 && Bowl21Awarded()){
			bowl+=1;
			return Action.Reset;
	}

		//strike on first ball of frame
		if (pins == 10 && bowl%2!=0) {
			bowl += 2;
			return Action.EndTurn;
		}



		//bowl less than strike on first ball of frame
		if (bowl % 2 != 0) { //mid frame or last frame
			bowl += 1;
			return Action.Tidy;

		} else if (bowl % 2 == 0) { //end of frame
			bowl+=1;
			return Action.EndTurn;
		}
			

		//other behaviours to go here

		throw new UnityException ("Not sure what action to return");
	}

	private bool Bowl21Awarded(){
		//remember arrays count from zero - hence the 1's
		return (bowls [19 - 1] + bowls [20 - 1] >= 10);
	}
}
