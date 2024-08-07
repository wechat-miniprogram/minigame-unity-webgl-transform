using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestBase : MonoBehaviour
{
    public static Dictionary<string, int> scores = new Dictionary<string, int>();
    public static int overall = 0;

    public int score = 0;
    public bool done = false;
    public float weight = 1.0f;

    IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(2);
        SceneSelect.SceneFinished();
    }

    public virtual void Done()
    {
        Debug.Log(SceneManager.GetActiveScene().name + " " + score);
        scores[SceneManager.GetActiveScene().name] = score;
        overall += (int)(score * weight);
        done = true;
        StartCoroutine(LoadNext());
    }
}
