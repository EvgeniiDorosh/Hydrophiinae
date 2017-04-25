using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldModel 
{
	Tile[][] tiles;

	public GameFieldModel (int level)
	{
		string filePath = Path.Combine(Application.streamingAssetsPath, string.Format("Level_{0}.txt", level));

		string[] rows = File.ReadAllLines(filePath);
		tiles = LevelParser.Parse (rows);
	}

	public delegate void TilesChangedHandler(List<Tile> changedTiles);
	public event TilesChangedHandler TilesChanged;

	public Tile[][] Tiles
	{
		get { return tiles;}
	}

	public int Width
	{
		get { return tiles [0].Length; }
	}

	public int Height
	{
		get { return tiles.Length; }
	}

	public void UpdateTiles(List<Tile> tiles)
	{
		foreach (Tile tile in tiles)
		{
			this.tiles [tile.x] [tile.y] = tile;
		}

		if (TilesChanged != null)
			TilesChanged (tiles);
	}
}
