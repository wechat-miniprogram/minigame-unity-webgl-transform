using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowResults : MonoBehaviour
{
    public Text names;
    public Text values;
    public Text overall;

    public bool showResultsOnFirstStart = true;

    public GameObject resultsCanvas;
    public GameObject testSelectCanvas;
    public GameObject toggleCanvas;
    public GameObject startButton;
    public GameObject restartButton;

    public SceneSelect sceneSelectScript;
    public ReadSceneNames sceneNamesScript;

    // Use this for initialization
    void Start()
    {
        if (!showResultsOnFirstStart && TestBase.scores.Count == 0)
        {
            resultsCanvas.SetActive(false);
            restartButton.SetActive(false);
            return;
        }
        else
        {
            testSelectCanvas.GetComponent<RectTransform>().sizeDelta += new Vector2(100, 0);
            toggleCanvas.GetComponent<RectTransform>().position -= new Vector3(60, 0, 0);
            startButton.SetActive(false);
            restartButton.SetActive(true);
        }

        string scoreText = "";
        bool hasAllScores = true;
        foreach (string scene in sceneNamesScript.testSceneNames)
        {
            if (TestBase.scores.ContainsKey(scene))
                scoreText += TestBase.scores[scene] + "\n";
            else
            {
                scoreText += "---\n";
                hasAllScores = false;
            }
        }
        values.text = scoreText;
        overall.text = !hasAllScores ? "---" : "" + TestBase.overall;

        foreach (var score in TestBase.scores)
            System.Console.WriteLine(score.Key + ": " + score.Value);
        System.Console.WriteLine("Overall: " + TestBase.overall);
    }

    void Update()
    {
        //#if UNITY_WEBGL && !UNITY_EDITOR
        //		Application.ExternalEval("SampleFrame();");
        //#endif
    }
}
