using UnityEngine;
using System.Collections.Generic;

public class SpawnController
{
	bool wasEaten = false;

	GameFieldModel fieldModel;
	PlayerModel playerModel;

	public SpawnController (GameFieldModel fieldModel, PlayerModel playerModel)
	{
		this.fieldModel = fieldModel;
		this.fieldModel.TilesChanged += OnTilesChanged;
		this.playerModel = playerModel;
		this.playerModel.PositionChanged += OnPlayerPositionChanged;

		wasEaten = true;
	}

	void OnPlayerPositionChanged(List<Tile> changedTiles)
	{
		Tile playerHead = changedTiles [0];
		TileType frontHeadTileType = fieldModel.Tiles[playerHead.x][playerHead.y].type;

		if (frontHeadTileType == TileType.Points)
			wasEaten = true;
	}

	void OnTilesChanged(List<Tile> changedTiles)
	{
		if (wasEaten)
		{
			wasEaten = false;
			Tile spawnedTile = SpawnPointsTile ();
			fieldModel.UpdateTiles (new List<Tile> { spawnedTile });
		}
	}

	Tile SpawnPointsTile()
	{
		List<Tile> possibleTiles = TileUtility.GetTiles (TileType.Empty, fieldModel.Tiles);
		Tile tile = possibleTiles [Random.Range (0, possibleTiles.Count)];
		return new Tile(tile.x, tile.y, TileType.Points);
	}
}

