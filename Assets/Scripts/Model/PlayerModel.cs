using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerModel
{
	public List<Tile> body;
	int freeParts = 0;

	FieldBounds bounds;

	FieldVector2 lastDirection;
	FieldVector2 direction;

	public PlayerModel(FieldBounds bounds, List<Tile> bodyTiles)
	{
		this.bounds = bounds;
		direction = FieldVector2.zero;
		lastDirection = FieldVector2.zero;
		body = bodyTiles;
	}

	public delegate void PositionChangedHandler(List<Tile> changedTiles);
	public event PositionChangedHandler PositionChanged;

	public int FreeParts 
	{ 
		get { return freeParts;}
		set { freeParts = value;}
	}

	public FieldVector2 Direction
	{ 
		get { return direction;}
		set { direction = value;}
	}

	public Tile Head
	{
		get { return body [0];}
	}

	public Tile Tail
	{
		get { return body [body.Count - 1];}
	}

	public void DefineHead(FieldVector2 direction)
	{
		if(direction == FieldVector2.up || direction == FieldVector2.right)
			body = body.OrderByDescending (i => i.y).ThenBy (i => i.x).ToList ();
		if(direction == FieldVector2.down || direction == FieldVector2.left)
			body = body.OrderBy (i => i.y).ThenByDescending (i => i.x).ToList ();
	}

	public void Move()
	{
		if (direction == -lastDirection)
			direction = lastDirection;

		List<Tile> changedTiles = new List<Tile> ();

		int x = MathUtil.Repeat (Head.x + direction.x, bounds.height);
		int y = MathUtil.Repeat (Head.y + direction.y, bounds.width);

		Tile newHead = new Tile (x, y, TileType.Body);
		body.Insert (0, newHead);
		changedTiles.Add (newHead);

		if (freeParts > 0)
		{
			freeParts--;
		}
		else
		{
			Tile oldTail = Tail;
			changedTiles.Add (new Tile (oldTail.x, oldTail.y, TileType.Empty));
			body.RemoveAt (body.Count - 1);
		}
		
		if (PositionChanged != null)
			PositionChanged (changedTiles);

		lastDirection = direction;
	}
}


