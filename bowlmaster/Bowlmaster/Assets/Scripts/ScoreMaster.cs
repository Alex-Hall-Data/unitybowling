using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//have a frame counter 

public class ScoreMaster {


	public static List<int> ScoreFrames(List<int> rolls){
		List <int> frameList = new List<int> ();


		int i=0;
		int frameCounter = 1;
		while (i < rolls.Count-1) {
			if (rolls [i] == 10) {//if strike 
				if (frameCounter!=10) {//if not in last frame
					if (rolls.Count <= 2) {//if first frame
						return frameList;
					} else {//add strike
						frameList = AddStrike (rolls,frameList,i);
						i++;
						frameCounter++;
					}
				} else {//if strike in last frame
					frameList = AddStrike (rolls,frameList,i);
					frameCounter++;
					return(frameList);
				}

			} else if (rolls [i] + rolls [i + 1] < 10) { //if not spare (or strike)
				frameList=AddBowls(rolls,i,frameList);
				frameCounter++;
				i += 2;
			} else {//if spare 
				if (rolls.Count > i + 2) {//(and next ball has been bowled)
					frameList = AddSpare (rolls, i, frameList);
					frameCounter++;
					i += 2;
				} else {
					return frameList;
				}
			}
		}


		return frameList;
	}


	//adds strike
	private static List<int> AddStrike(List<int> Rolls, List<int> FrameList,int I){
		int frameScore = 10 + Rolls [I + 1] + Rolls [I + 2];
		FrameList.Add (frameScore);
		return FrameList;
	}


	//adds results of frame to list
	private static List<int> AddBowls(List <int> Rolls, int I, List <int> FrameList){
		int frameScore = Rolls [I] + Rolls [I + 1];
		FrameList.Add (frameScore);
		return FrameList;
	}

	//adds result of spare to framelist
	private static List <int> AddSpare(List <int> Rolls, int I, List <int> FrameList){
		int frameScore = 10 + Rolls [I + 2];
		FrameList.Add (frameScore);
		return FrameList;
	}

	//makes cumulativescore list
	public static List <int> ScoreCumulative(List<int> rolls){
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}
}
