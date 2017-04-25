using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController
{
	PlayerModel playerModel;
	GameFieldModel gameFieldModel;
	LevelModel levelModel;
	LevelView levelView;

	StepTimer timer;

	public LevelController (PlayerModel playerModel, GameFieldModel gameFieldModel, LevelModel levelModel, LevelView levelView, StepTimer timer)
	{
		this.playerModel = playerModel;
		this.gameFieldModel = gameFieldModel;
		this.levelModel = levelModel;
		this.levelView = levelView;

		this.timer = timer;

		InitLevelData ();
	}

	void InitLevelData()
	{
		int level = GameController.CurrentLevel;

		playerModel.PositionChanged += OnPlayerPositionChanged;

		levelModel.LivesChangedHandler += OnLivesChanged;
		levelModel.LevelOver += OnLevelOver;
		levelModel.Lives = 1;
		levelModel.PlayerScore = 0;
		levelModel.PicksForOver = 10 + (int)Mathf.Log(level);

		timer.Ticked += OnTicked;
		timer.Duration = 1f / (2 * level);
	}

	void OnTicked(object sender, EventArgs e)
	{
		playerModel.Move ();
		levelModel.PlayerScore -= 1;
	}

	void OnPlayerPositionChanged(List<Tile> changedTiles)
	{
		Tile playerHead = changedTiles [0];
		TileType frontHeadTileType = gameFieldModel.Tiles[playerHead.x][playerHead.y].type;

		switch (frontHeadTileType)
		{
		case TileType.Block:
		case TileType.Body:
			levelModel.Lives -= 1;
			break;
		case TileType.Points:
			OnPickPoint ();
			gameFieldModel.UpdateTiles (changedTiles);
			break;
		case TileType.Empty:
			gameFieldModel.UpdateTiles (changedTiles);
			break;
		default:
			break;
		}
	}

	void OnLivesChanged(object sender, EventArgs e)
	{
		if (levelModel.Lives <= 0)
		{
			SaveScore ();
			levelView.LevelLost();
		}			
	}

	void OnPickPoint()
	{
		playerModel.FreeParts += levelModel.Multiplier;
		levelModel.PlayerScore += levelModel.PointPerPick * levelModel.Multiplier;
		levelModel.PickedPoints += 1;
		levelModel.Multiplier += 1;
	}

	void OnLevelOver(object sender, EventArgs e)
	{
		int level = GameController.CurrentLevel;
		SaveScore ();
		GameController.LoadLevel (level + 1);
	}

	void SaveScore()
	{
		int level = GameController.CurrentLevel;

		if (levelModel.PlayerScore > PrefsManager.GetScore (level))
			PrefsManager.SetScore (level, levelModel.PlayerScore);
	}
}


