using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerBase.Instance.SaveData();
            StartCoroutine(LoadSceneWithFade(levelToLoad));
        }
    }

    private IEnumerator LoadSceneWithFade(string sceneName)
    {
        yield return FadeManager.Instance.FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
