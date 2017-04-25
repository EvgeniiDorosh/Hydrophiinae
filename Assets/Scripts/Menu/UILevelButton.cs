using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelButton : MonoBehaviour 
{
	[SerializeField]
	int level;
	[SerializeField]
	Text levelText;
	[SerializeField]
	Text scoreText;

	Image image;

	public void UpdateState()
	{
		int score = PrefsManager.GetScore (level);
		scoreText.text = score.ToString();
		scoreText.enabled = score > 0;

		image.color = score > 0 ? Color.yellow : Color.grey;
	}

	public void LoadLevel()
	{
		GameController.LoadLevel (level);
	}

	void Awake()
	{
		image = GetComponent<Image> ();
		levelText.text = level.ToString ();
		UpdateState ();
	}
}
