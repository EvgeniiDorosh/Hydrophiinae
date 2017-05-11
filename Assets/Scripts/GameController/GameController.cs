using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	static GameController instance = null;
	static int currentLevel = -1;

	public static GameController Instance 
	{
		get { return instance;}
	}

	public static int CurrentLevel
	{
		get { return currentLevel;}
	}

	public static void LoadLevel(int level)
	{
		if (level <= Settings.maxLevel)
		{
			currentLevel = level;
			SceneManager.LoadScene ((int)GameScene.Level);
		}
		else
		{
			LoadMenu ();
		}
	}

	public static void LoadMenu()
	{
		currentLevel = -1;
		SceneManager.LoadScene ((int)GameScene.Menu);
	}

	void Awake() 
	{
		if (instance != null) 
		{
			DestroyImmediate (gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad (gameObject);
	}
}

