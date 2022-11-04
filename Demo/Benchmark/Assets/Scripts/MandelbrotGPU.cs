using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MandelbrotGPU : FPSTest {

	public Material output;
    public RectTransform image;

/*    float scale = 1.0f;
    float xShift = 0;
    int MaxIterations = 1;
  */
    float scale = 0.1f;
    float xShift = 1.2f;
    int accumulatedScore = 0;
    //int MaxIterations = 1;

	public override void UpdateTest () {
        output.SetFloat ("_Scale", scale);
        output.SetFloat ("_xShift", xShift);
        //output.SetFloat ("_MaxIter", MaxIterations);

        if (curFPS != -1)
        {
            if (image.sizeDelta.x < Screen.width && image.sizeDelta.y < Screen.height)
                image.sizeDelta = new Vector2(image.sizeDelta.x + 1, image.sizeDelta.y + 1);
            else
            {
                accumulatedScore += (int)(image.sizeDelta.x * image.sizeDelta.y);
                RectTransform newImage = Instantiate(image.gameObject).GetComponent<RectTransform>();
                newImage.parent = image.parent;
                newImage.SetSiblingIndex(image.GetSiblingIndex()+1);
                newImage.pivot = image.pivot;
                newImage.anchoredPosition = image.anchoredPosition;
                image = newImage;
                image.sizeDelta = Vector2.one;
            }
            score = accumulatedScore + (int)(image.sizeDelta.x * image.sizeDelta.y);
        }
	}
}
