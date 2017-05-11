using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusPanelView : MonoBehaviour
{
	[SerializeField]
	Text levelText;
	[SerializeField]
	Text scoreText;
	[SerializeField]
	Text bestScoreText;
	[SerializeField]
	Text picksText;

	void Awake ()
	{
		bestScoreText.text = PrefsManager.GetScore (GameController.CurrentLevel).ToString();
		levelText.text = GameController.CurrentLevel.ToString ();
	}

	public int Score
	{
		set { scoreText.text = value.ToString (); }
	}

	public int PicksForOver
	{
		set { picksText.text = value.ToString(); }
	}
}

