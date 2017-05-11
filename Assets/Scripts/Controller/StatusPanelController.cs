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
		levelModel.PickedPointsChangedHandler += UpdatePicks;
	}

	void UpdateScore(object sender, EventArgs e)
	{
		statusView.Score = levelModel.PlayerScore;
	}

	void UpdatePicks(object sender, EventArgs e)
	{
		statusView.PicksForOver = levelModel.PicksForOver - levelModel.PickedPoints;
	}
}


