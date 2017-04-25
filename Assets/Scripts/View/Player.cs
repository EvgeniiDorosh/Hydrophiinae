using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public delegate void DirectionChangedDelegate(FieldVector2 direction);
	public event DirectionChangedDelegate DirectionChangedHandler;

	void Update()
	{		
		if (Input.GetKeyDown (KeyCode.LeftArrow))
			ChangeDirection(FieldVector2.left);
		if (Input.GetKeyDown (KeyCode.RightArrow))
			ChangeDirection(FieldVector2.right);		
		if (Input.GetKeyDown (KeyCode.UpArrow))
			ChangeDirection(FieldVector2.up);
		if (Input.GetKeyDown (KeyCode.DownArrow))
			ChangeDirection(FieldVector2.down);
	}

	void ChangeDirection(FieldVector2 direction)
	{
		if (DirectionChangedHandler != null)
			DirectionChangedHandler (direction);
	}
}
