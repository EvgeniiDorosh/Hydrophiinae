using UnityEngine;

public class UIResetPopup : MonoBehaviour 
{
	public void ResetProgress()
	{
		PrefsManager.ClearProgress ();
		UILevelButton[] levelButtons = FindObjectsOfType<UILevelButton> ();
		foreach (var button in levelButtons) 
			button.UpdateState ();
	}
}
