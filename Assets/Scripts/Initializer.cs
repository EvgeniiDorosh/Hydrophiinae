using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
	[SerializeField]
	GameObject gameField;
	[SerializeField]
	GameObject player;
	[SerializeField]
	GameObject statusPanel;

	void Start () 
	{
		GameFieldModel fieldModel = new GameFieldModel (GameController.CurrentLevel);
		PlayerModel playerModel = new PlayerModel (new FieldBounds (fieldModel.Width, fieldModel.Height), 
													TileUtility.GetTiles (TileType.Body, fieldModel.Tiles));

		GameFieldView fieldView = gameField.GetComponent<GameFieldView> ();
		Player playerView = player.GetComponent<Player> ();

		PlayerController playerController = new PlayerController (playerModel, playerView);
		GameFieldController gameFieldController = new GameFieldController (fieldModel, fieldView);

		LevelModel levelModel = new LevelModel ();
		LevelView levelView = GetComponent<LevelView> ();

		StepTimer tickTimer = GetComponent<StepTimer> ();
		StepTimerController timerController = new StepTimerController (levelModel, playerView, tickTimer);

		StatusPanelView statusView = statusPanel.GetComponent<StatusPanelView> ();
		StatusPanelController statusPanelController = new StatusPanelController (levelModel, statusView);

		SpawnController spawnController = new SpawnController (fieldModel, playerModel);

		LevelController levelController = new LevelController (playerModel, fieldModel, levelModel, levelView, tickTimer);
	}
}
