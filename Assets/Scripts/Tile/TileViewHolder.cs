using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class TileViewHolder : MonoBehaviour
{
	static TileViewHolder instance = null;
	static Dictionary<TileType, Sprite[]> tiles;

	[SerializeField]
	TileView[] tileViews;

	public static TileViewHolder Instance 
	{
		get { return instance;}
	}

	public static Sprite GetTileSprite(TileType type)
	{
		Sprite[] sprites;

		if (tiles.ContainsKey (type))
		{
			sprites = tiles [type];
			if (sprites != null && sprites.Length > 0)
				return sprites [Random.Range (0, sprites.Length)];
		}

		return null;	 
	}

	void Awake ()
	{
		if (instance != null) 
		{
			DestroyImmediate (gameObject);
			return;
		}

		instance = this;
		InitTiles ();
	}

	void InitTiles()
	{
		tiles = new Dictionary<TileType, Sprite[]> ();

		foreach (TileView tile in tileViews)
			if (!tiles.ContainsKey (tile.type))
				tiles.Add (tile.type, tile.sprites);
	}

	[Serializable]
	public class TileView
	{
		public TileType type;
		public Sprite[] sprites;
	}
}

