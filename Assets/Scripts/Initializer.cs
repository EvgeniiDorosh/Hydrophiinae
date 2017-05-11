using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Initializer : MonoBehaviour
{
	[SerializeField]
	GameObject gameField;
	[SerializeField]
	GameObject player;
	[SerializeField]
	GameObject statusPanel;

	IEnumerator Start () 
	{
		string filePath = Path.Combine(Application.streamingAssetsPath, string.Format("Level_{0}.txt", GameController.CurrentLevel));
		string result;

		if (filePath.Contains ("://"))
		{
			WWW www = new WWW (filePath);
			yield return www;
			result = www.text;
		}
		else
		{
			result = File.ReadAllText (filePath);
		}

		string[] rows = Regex.Split(result, "\r\n|\r|\n");

		InitLevel (rows);
	}

	void InitLevel(string[] rows)
	{
		GameFieldModel fieldModel = new GameFieldModel (rows);
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
