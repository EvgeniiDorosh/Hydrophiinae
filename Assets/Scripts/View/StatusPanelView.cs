using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusPanelView : MonoBehaviour
{
	[SerializeField]
	Text livesText;
	[SerializeField]
	Text scoreText;
	[SerializeField]
	Text bestScoreText;

	void Awake ()
	{
		bestScoreText.text = PrefsManager.GetScore (GameController.CurrentLevel).ToString();
	}

	public int Lives
	{
		set { livesText.text = value.ToString (); }
	}

	public int Score
	{
		set { scoreText.text = value.ToString (); }
	}
}

