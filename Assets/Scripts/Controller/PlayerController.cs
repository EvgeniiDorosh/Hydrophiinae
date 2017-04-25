public class PlayerController
{
	PlayerModel playerModel;
	Player playerView;

	public PlayerController (PlayerModel playerModel, Player playerView)
	{
		this.playerModel = playerModel;
		this.playerView = playerView;

		playerView.DirectionChangedHandler += OnDirectionChanged;
		playerView.DirectionChangedHandler += DefineHead;
	}

	void OnDirectionChanged(FieldVector2 direction)
	{
		playerModel.Direction = direction;
	}

	void DefineHead(FieldVector2 direction)
	{
		playerView.DirectionChangedHandler -= DefineHead;
		playerModel.DefineHead (direction);
	}
}

