using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{

	public static List<string> selectedScenes = new List<string>();

	public ReadSceneNames sceneNamesScript;
	public int toggleHeight;
	public Toggle togglePrefab;
	public GameObject toggleCanvas;

	private static int currentSceneIndex;
	private List<Toggle> toggles = new List<Toggle>();


	void Start()
	{
		sceneNamesScript = gameObject.GetComponent<ReadSceneNames>();
		List<string> sceneNames = sceneNamesScript.testSceneNames;

		for (int i = 0; i < sceneNames.Count; i++)
		{
			createOneToggle(new Vector2(0.0f, -i * toggleHeight), sceneNames[i]);
			if (selectedScenes.Count != 0 && !selectedScenes.Contains(sceneNames[i]))
				toggles[toggles.Count - 1].isOn = false;
		}
	}


	public static void SceneFinished()
	{
		if (selectedScenes.Count == 0)
			return;
		if (currentSceneIndex == selectedScenes.Count - 1)
			SceneManager.LoadScene("Results");
		else
			SceneManager.LoadScene(selectedScenes[++currentSceneIndex]);
	}


	void createOneToggle(Vector2 position, string label)
	{
 		Toggle toggle = (Toggle)Instantiate(togglePrefab);
		RectTransform toggleTransform = (RectTransform)toggle.transform;
		toggleTransform.parent = toggleCanvas.transform;
		toggleTransform.localScale = Vector3.one;
		toggleTransform.anchoredPosition = new Vector3(position.x, position.y, 0.0f);
		toggle.GetComponentInChildren<Text>().text = label;
		toggles.Add(toggle);
	}

	public void SelectAllToggled(bool activated)
	{
		foreach (Toggle t in toggles)
			t.isOn = activated;
	}

	public void StartButtonPressed()
	{
		selectedScenes.Clear();
		TestBase.scores.Clear();
		TestBase.overall = 0;
		foreach (Toggle t in toggles) {
			if (t.isOn)
				selectedScenes.Add(t.GetComponentInChildren<Text>().text);
		}
		if (selectedScenes.Count == 0)
			return;
		currentSceneIndex = 0;
		SceneManager.LoadScene(selectedScenes[0]);
	}
}
