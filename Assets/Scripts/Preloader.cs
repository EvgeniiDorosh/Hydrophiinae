using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour 
{
	LineRenderer lineRenderer;


	[SerializeField]
	GameObject logo;

	IEnumerator Start () 
	{
		logo.SetActive (false);
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.numPositions = 5;
		yield return new WaitForSeconds(1f);
		float size = 4;
		float diff = -1f;
		while (size > 0) 
		{
			yield return StartCoroutine (ShowSquare (size, 0.5f));
			size += diff;
		}
		logo.SetActive (true);
		yield return new WaitForSeconds(2f);
		StopAllCoroutines ();
		SceneManager.LoadScene (1);
	}

	IEnumerator ShowSquare(float a, float time)
	{
		float counter = 0;
		while (counter < a) 
		{
			lineRenderer.SetPosition (0, new Vector2(counter, counter));
			lineRenderer.SetPosition (1, new Vector2(counter, -counter));
			lineRenderer.SetPosition (2, new Vector2(-counter, -counter));
			lineRenderer.SetPosition (3, new Vector2(-counter, counter));
			lineRenderer.SetPosition (4, new Vector2(counter, counter));
			counter += a * Time.deltaTime / time;
			yield return null;
		}
	}
}
