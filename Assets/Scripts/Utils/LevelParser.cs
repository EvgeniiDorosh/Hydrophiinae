using System.Linq;
using UnityEngine;

public static class LevelParser
{
	public static Tile[][] Parse(string[] rows)
	{
		int maxRowLength = rows.Max ().Length;
		int rowsAmount = rows.Length;

		string[] normalizedRows = new string[rowsAmount];
		for (int i = 0; i < rowsAmount; i++)
			normalizedRows [i] = rows [i].PadRight (maxRowLength, TileKey.Block);

		Tile[][] result = new Tile[rowsAmount] [];

		for (int x = 0; x < rowsAmount; x++) 
		{
			result [x] = new Tile[maxRowLength];
			for (int y = 0; y < maxRowLength; y++) 
			{
				result [x] [y] = new Tile (x, y, TileUtility.GetType (normalizedRows[x][y]));
			}
		}

		return result;
	}
}
