using System;

public class StepTimerController
{
	LevelModel levelModel;
	Player playerView;
	StepTimer timer;

	public StepTimerController (LevelModel levelModel, Player playerView, StepTimer timer)
	{
		this.levelModel = levelModel;
		this.playerView = playerView;
		this.timer = timer;

		this.levelModel.LivesChangedHandler += OnLivesChanged;
		this.playerView.DirectionChangedHandler += OnDirectionChanged;
	}

	void OnDirectionChanged(FieldVector2 direction)
	{
		if (!timer.IsRunning)
		{
			timer.Run ();
			playerView.DirectionChangedHandler -= OnDirectionChanged;
		}
	}

	void OnLivesChanged(object sender, EventArgs e)
	{
		if (levelModel.Lives <= 0)
			timer.Stop ();
	}
}

