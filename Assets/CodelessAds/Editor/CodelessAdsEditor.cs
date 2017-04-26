using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.Events;

public class CodelessAdsEditor : MonoBehaviour
{
	[MenuItem("Unity Ads/Create Unity Ads Button")]
	static void CreateAdsButton()
	{
		// Create Button
		EditorApplication.ExecuteMenuItem("GameObject/UI/Button");

		// Get GameObject of Button
		GameObject gameObject = Selection.activeGameObject;
		CodelessAds codelessAds = gameObject.AddComponent<CodelessAds> ();
		Button button = gameObject.GetComponent<Button> ();
//		button.onClick.AddListener (codelessAds.ShowAds);
		UnityEventTools.AddPersistentListener (button.onClick, codelessAds.ShowAds);
		Text text = button.GetComponentInChildren<Text> ();
		text.text = "Show Unity Ads";
	}
}
