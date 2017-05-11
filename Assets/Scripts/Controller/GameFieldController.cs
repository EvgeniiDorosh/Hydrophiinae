using System.Collections.Generic;

public class GameFieldController 
{
	GameFieldModel model;
	GameFieldView view;

	public GameFieldController(GameFieldModel model, GameFieldView view)
	{
		this.model = model;
		this.view = view;

		InitGameField ();
	}

	void InitGameField()
	{
		view.SetField (model.Tiles);

		model.TilesChanged += OnTilesChanged;
	}

	void OnTilesChanged(List<Tile> changedTiles)
	{
		view.SetTiles (changedTiles);
	}
}
