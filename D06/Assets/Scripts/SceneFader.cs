using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public CanvasGroup UI;
    public Text infotext;

    public void FadeIn()
    {
        StartCoroutine(FadeScene(UI, UI.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeScene(UI, UI.alpha, 0));
    }

    public void insertText(string text)
    {
        infotext.text = text;
        FadeIn();
    }

    public IEnumerator FadeScene (CanvasGroup canvasGroup, float start, float end, float lerptime = 0.3f)
    {
        float timeStart = Time.time;
        float timeSinceStarted = Time.time - timeStart;
        float percentage = timeSinceStarted / lerptime;

        while (true)
        {
            timeSinceStarted = Time.time - timeStart;
            percentage = timeSinceStarted / lerptime;
            float currentValue = Mathf.Lerp(start, end, percentage);

            canvasGroup.alpha = currentValue;
            if (percentage >= 1)
                break;
                                   
            yield return new WaitForEndOfFrame();
        }
    }
}
