using System;
using System.Collections;
using UnityEngine;

public class StepTimer : MonoBehaviour 
{
	float duration;
	bool isRunning = false;
	WaitForSeconds waiting;

	public event EventHandler Ticked;

	public float Duration
	{
		get { return duration;}
		set 
		{ 
			duration = Mathf.Clamp(value, 0, value);
			waiting = new WaitForSeconds (duration);
		}
	}

	public bool IsRunning
	{
		get { return isRunning;}
	}

	public void Run () 
	{
		StopAllCoroutines ();
		isRunning = true;
		StartCoroutine (Ticking ());
	}

	public void Stop()
	{
		isRunning = false;
		StopAllCoroutines ();
	}

	void Awake()
	{
		waiting = new WaitForSeconds (duration);
	}
	
	IEnumerator Ticking()
	{
		while (isRunning) 
		{
			yield return waiting;
			if (Ticked != null)
				Ticked (this, null);
		}
	}
}
