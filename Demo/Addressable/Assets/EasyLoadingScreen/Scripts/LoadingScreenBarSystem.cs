using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenBarSystem : MonoBehaviour
{
    public GameObject bar;
    public Text loadingText;
    public bool backGroundImageAndLoop;
    public float LoopTime;
    public GameObject[] backgroundImages;

    [Range(0, 1f)]
    public float vignetteEfectVolue; // Must be a value between 0 and 1
    AsyncOperation async;
    Image vignetteEfect;

    // Used to try. Delete the comment lines (25 and 36)
    /*
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bar.transform.localScale += new Vector3(0.001f,0,0);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");
        }
    }
    */

    private void Start()
    {
        vignetteEfect = transform.Find("VignetteEfect").GetComponent<Image>();
        vignetteEfect.color = new Color(
            vignetteEfect.color.r,
            vignetteEfect.color.g,
            vignetteEfect.color.b,
            vignetteEfectVolue
        );

        if (backGroundImageAndLoop)
            StartCoroutine(transitionImage());
        StartCoroutine(LoadMain());
    }

    // The pictures change according to the time of
    IEnumerator transitionImage()
    {
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            yield return new WaitForSeconds(LoopTime);
            for (int j = 0; j < backgroundImages.Length; j++)
                backgroundImages[j].SetActive(false);
            backgroundImages[i].SetActive(true);
        }
    }

    // Activate the scene
    IEnumerator LoadMain()
    {
        var handle = Addressables.LoadSceneAsync(
            "Assets/RPGPP_LT/Scene/rpgpp_lt_scene_1.0.unity",
            LoadSceneMode.Single,
            true
        );
        handle.Completed += (obj) =>
        {
            Debug.LogWarning($"Load async scene complete{obj.Status}");
        };

        while (!handle.IsDone)
        {
            bar.transform.localScale = new Vector3(handle.PercentComplete, 0.9f, 1);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");

            if (handle.PercentComplete == 0.9f)
            {
                bar.transform.localScale = new Vector3(1, 0.9f, 1);
            }
            yield return null;
        }
    }
}
