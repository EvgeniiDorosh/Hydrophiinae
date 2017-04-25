using System;

public class StatusPanelController
{
	LevelModel levelModel;
	StatusPanelView statusView;

	public StatusPanelController (LevelModel levelModel, StatusPanelView statusView)
	{
		this.levelModel = levelModel;
		this.statusView = statusView;

		levelModel.ScoreChangedHandler += UpdateScore;
		levelModel.LivesChangedHandler += UpdateLives;
	}

	void UpdateScore(object sender, EventArgs e)
	{
		statusView.Score = levelModel.PlayerScore;
	}

	void UpdateLives(object sender, EventArgs e)
	{
		statusView.Lives = levelModel.Lives;
	}
}


