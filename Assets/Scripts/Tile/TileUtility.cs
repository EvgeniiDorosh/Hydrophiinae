using UnityEngine;
using System.Collections.Generic;

public static class TileUtility
{
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
}
