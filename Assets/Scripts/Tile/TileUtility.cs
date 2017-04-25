using UnityEngine;
using System.Collections.Generic;

public static class TileUtility
{
	static Dictionary<TileType, Color32> colors;

	static TileUtility()
	{
		InitTileColors ();
	}

	public static Color GetColor(TileType type)
	{
		return colors [type]; 
	}

	public static TileType GetType(char key)
	{
		TileType result = TileType.Empty;
		switch (key) 
		{
		case TileKey.Block :
			result = TileType.Block;
			break;
		case TileKey.Body :
			result = TileType.Body;
			break;
		default :
			break;
		}

		return result;
	}

	public static List<Tile> GetTiles(TileType type, Tile[][] field)
	{
		List<Tile> result = new List<Tile> ();
		int columns = field[0].Length;
		int rows = field.Length;

		for (int x = 0; x < rows; x++) 
		{
			for (int y = 0; y < columns; y++) 
			{
				if (field [x] [y].type == type)
					result.Add (field [x] [y]);
			}
		}

		return result;
	}

	static void InitTileColors()
	{
		colors = new Dictionary<TileType, Color32>();
		colors [TileType.Block] = new Color32 (225, 108, 23, 255);
		colors [TileType.Empty] = new Color32 (125, 0, 90, 255);
		colors [TileType.Body] = new Color32 (114, 242, 30, 255);
		colors [TileType.Points] = new Color32 (255, 255, 255, 255);
	}
}
