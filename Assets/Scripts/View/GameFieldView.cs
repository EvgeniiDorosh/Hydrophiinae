using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFieldView : MonoBehaviour 
{
	[SerializeField]
	GameObject tilePrefab;

	GridLayoutGroup layoutGroup;
	RectTransform rectTransform;

	Image[][] images;

	void Awake () 
	{
		layoutGroup = GetComponent<GridLayoutGroup> ();
		rectTransform = GetComponent<RectTransform> ();
	}

	public void SetField(Tile[][] tiles)
	{
		int fieldTilesWidth = tiles [0].Length;
		int fieldTilesHeight = tiles.Length;

		float preferredWidth = rectTransform.rect.width / fieldTilesWidth;
		float preferredHeight = rectTransform.rect.height / fieldTilesHeight;

		float preferredTileSide = preferredWidth < preferredHeight ? preferredWidth : preferredHeight;

		layoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
		layoutGroup.constraintCount = fieldTilesWidth;
		layoutGroup.cellSize = new Vector2 (preferredTileSide, preferredTileSide);

		images = new Image[fieldTilesHeight][];
		GameObject cloneTile;
		Image image;

		for (int x = 0; x < fieldTilesHeight; x++) 
		{
			images [x] = new Image[fieldTilesWidth];
			for (int y = 0; y < fieldTilesWidth; y++)
			{
				cloneTile = Instantiate (tilePrefab, transform) as GameObject;
				cloneTile.transform.localScale = Vector3.one;
				image = cloneTile.GetComponent<Image> ();
				image.sprite = TileViewHolder.GetTileSprite (tiles [x] [y].type);
				images [x] [y] = image;
			}
		}
	}

	public void SetTiles(List<Tile> tiles)
	{
		foreach (Tile tile in tiles) 
			images [tile.x] [tile.y].sprite = TileViewHolder.GetTileSprite (tile.type);
	}
}
