using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BenchmarkHUD : MonoBehaviour {

	public Text testLabel;
	public Text score;
	public Text fps;
	public Image background;

	TestBase test;

	void Start () {
		test = FindObjectOfType<TestBase>();
		testLabel.text = SceneManager.GetActiveScene().name;
	}
	
	void Update () {
		score.text = test.score.ToString("D7");
		if (test.done)
		{
			score.color = Color.grey;
			testLabel.color = Color.grey;
			background.color = Color.black;
		}
        /*		var curFPS = test.curFPS;
                if (curFPS > 0)
        //			fps.text = "FPS: " + test.curFPS.ToString("F1");
                    fps.text = "FPS: " + ((int)curFPS).ToString("D2")+"."+((int)((curFPS-Mathf.Floor(curFPS))*10)).ToString("D1");
                else
                    fps.text = "FPS: --.-";*/
    }
}
