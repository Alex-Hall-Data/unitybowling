using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;



[TestFixture]
public class ActionMasterTest{
	
	private List <int> pinFalls;
	private ActionMaster.Action endTurn=ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy=ActionMaster.Action.Tidy;
	private ActionMaster.Action reset=ActionMaster.Action.Reset;
	private ActionMaster.Action endGame=ActionMaster.Action.EndGame;

	[SetUp]
	public void Setup(){
		pinFalls = new List<int> ();
	}

	[Test]
	public void T00PassingTest(){
		Assert.AreEqual (1, 1);
	}

	//strike ends turn
	[Test]
	public void T01OneStrikeReturnsEndTurn(){
		pinFalls.Add (10);
		Assert.AreEqual(endTurn,ActionMaster.NextAction(pinFalls));
	}


	[Test]
	public void T02BowlLessThanTenReturnsTidy(){
		pinFalls.Add (8);
		Assert.AreEqual(tidy,ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T03BowlSpareReturnsEndTurn(){
		int[] rolls = { 8, 2 };
			Assert.AreEqual(endTurn,ActionMaster.NextAction(rolls.ToList()));
	}


	[Test]
	public void T04CheckResetAtLastFrameStrike(){
		//bowl 18 balls to get to last frame
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10 };
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
	}


	[Test]
	public void T05CheckResetAtLastFrameSpare(){
		//bowl 18 balls to get to last frame
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1,9};
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
	}


	[Test]
	public void T06EndGame(){
		int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 ,9};
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07GameEndsAtBowl20(){
		//bowl 18 balls to get to last frame
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1 };
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T08TidyIfStrikeThenNotOnLastFrame(){
		//bowl 18 balls to get to last frame
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,1 };
		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T09GutterBallThenStrikeEndsTurn(){
		int[] rolls = { 0 ,10,5,5};
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T10LastFrameTurkey(){
		//bowl 18 balls to get to last frame
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,10 ,10};
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
	}


	[Test]
	public void T11ResetOnLastFrameTwoStrikes(){
		//bowl 18 balls to get to last frame
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,10 };
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
	}
}