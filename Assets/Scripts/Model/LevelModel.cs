using System;
using UnityEngine;

public class LevelModel
{
	int playerLives = -1;
	int playerScore = -1;

	int pointPerPick = 100;
	int pickedPoints = 0;
	int picksForOver = 0;
	int multiplier = 1;

	public event EventHandler ScoreChangedHandler;
	public event EventHandler LivesChangedHandler;

	public event EventHandler LevelOver;

	public int PlayerScore
	{
		get { return playerScore;}
		set 
		{			
			playerScore = Mathf.Clamp(value, 0, value);
			if (ScoreChangedHandler != null)
				ScoreChangedHandler (this, null);
		}
	}

	public int Lives
	{
		get { return playerLives;}
		set 
		{ 
			if (playerLives != value)
			{
				playerLives = value;
				if (LivesChangedHandler != null)
					LivesChangedHandler (this, null);
			}
		}
	}

	public int PointPerPick
	{
		get { return pointPerPick;}
		set { pointPerPick = Mathf.Clamp (value, 1, value);}
	}

	public int PickedPoints
	{
		get { return pickedPoints;}
		set 
		{ 
			pickedPoints = Mathf.Clamp (value, 0, value);
			if (pickedPoints >= picksForOver)
			{
				if (LevelOver != null)
					LevelOver (this, null);
			}

		}
	}

	public int PicksForOver
	{
		get { return picksForOver;}
		set { picksForOver = Mathf.Clamp (value, 1, value); }
	}

	public int Multiplier
	{
		get { return multiplier;}
		set { multiplier = Mathf.Clamp (value, 1, value);}
	}
}

