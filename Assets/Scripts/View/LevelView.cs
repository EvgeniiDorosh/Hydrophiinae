using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
	bool gamePaused = false;

	AudioSource audioSource;

	[SerializeField]
	Text LevelText;
	[SerializeField]
	GameObject loseLevelPopup;
	[SerializeField]
	AudioClip crashSound;
	[SerializeField]
	GameObject quitLevelPopup;

	public void QuitLevel()
	{
		Time.timeScale = 1;
		GameController.LoadMenu ();
	}

	public void PauseGame(bool value)
	{
		gamePaused = value;
		Time.timeScale = value ? 0 : 1;
		quitLevelPopup.SetActive (value);
	}

	public void RestartLevel()
	{
		GameController.LoadLevel (GameController.CurrentLevel);
	}

	public void LevelLost()
	{
		audioSource.clip = crashSound;
		audioSource.Play ();
		loseLevelPopup.SetActive (true);
	}

	void Awake()
	{
		LevelText.text = string.Format ("Level {0}", GameController.CurrentLevel);
		audioSource = GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			PauseGame (!gamePaused);
		}
	}	 
}


