﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayButton : MonoBehaviour {

	public void PlayFromBeginning()
	{
		GameController.LoadLevel (1);
	}
}
