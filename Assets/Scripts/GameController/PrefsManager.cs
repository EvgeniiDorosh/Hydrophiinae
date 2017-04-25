using UnityEngine;

public static class PrefsManager 
{
	public static void SetScore(int level, int score)
	{
		SetScore (level.ToString (), score);
	}

	public static void SetScore(string level, int score)
	{
		PlayerPrefs.SetInt (level, score);
		PlayerPrefs.Save ();
	}

	public static int GetScore(int level)
	{
		return GetScore(level.ToString ());
	}

	public static int GetScore(string level)
	{
		return PlayerPrefs.GetInt (level, 0);
	}

	public static void ClearProgress() 
	{
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
	}
}
