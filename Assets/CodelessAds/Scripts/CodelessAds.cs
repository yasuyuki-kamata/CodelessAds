#if UNITY_ADS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class CodelessAds : MonoBehaviour
{
	[SerializeField]
	UnityEvent OnFinishedCallcack;
	[SerializeField]
	UnityEvent OnSkippedCallback;
	[SerializeField]
	UnityEvent OnFailedCallback;

	void Start ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;
	}

	public void ShowAds ()
	{
		if (Advertisement.IsReady ()) {
			Advertisement.Show ();
		}
	}

	private void HandleShowResult (ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("Video completed.");
			OnFinishedCallcack.Invoke ();
			break;
		case ShowResult.Skipped:
			Debug.LogWarning ("Video was skipped.");
			OnSkippedCallback.Invoke ();
			break;
		case ShowResult.Failed:
			Debug.LogError ("Video failed to show.");
			OnFailedCallback.Invoke ();
			break;
		}
	}
}
#endif