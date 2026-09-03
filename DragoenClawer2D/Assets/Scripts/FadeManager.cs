using System.Collections;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuretion = 0.5f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        fadeCanvasGroup.alpha = 1;
        float t = 0;
        while (t < fadeDuretion)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = 1 - (t / fadeDuretion);
            yield return null;
        }
        fadeCanvasGroup.alpha = 0;
    }


    public IEnumerator FadeOut()
    {
        fadeCanvasGroup.alpha = 0;
        float t = 0;
        while (t < fadeDuretion)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = t / fadeDuretion;
            yield return null;
        }
        fadeCanvasGroup.alpha = 1;
    }
}
