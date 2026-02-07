using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    public Image solidColorImage;
    public GameObject youDiedPanel;
    bool retryButtonPressed;
    AsyncOperation asyncLoad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            solidColorImage.color = new Color(1, 1, 1, 0);
            solidColorImage.raycastTarget = false;
            solidColorImage.gameObject.SetActive(false);

            youDiedPanel.SetActive(false);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FadeWhite(string sceneName)
    {
        if(asyncLoad != null)
            return;
        Debug.Log("Fading to white and loading scene: " + sceneName);
        solidColorImage.gameObject.SetActive(true);
        solidColorImage.raycastTarget = true;
        solidColorImage.color = new Color(1, 1, 1, 0);
        asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        StartCoroutine(FadeToWhite(1f));
    }

    IEnumerator FadeToWhite(float duration)
    {
        float t = 0;
        Color originalColor = solidColorImage.color;
        Color targetColor = Color.white;
        while (t < duration)
        {
            t += Time.deltaTime;
            solidColorImage.color = Color.Lerp(originalColor, targetColor, t / duration);
            yield return null;
        }
        solidColorImage.color = targetColor;
        Debug.Log("Scene loaded, allow scene activation.");
        asyncLoad.allowSceneActivation = true;
        asyncLoad = null;
        StartCoroutine(FadeToClear(1f));
    }

    IEnumerator FadeToClear(float duration)
    {
        float t = 0;
        Color originalColor = solidColorImage.color;
        Color targetColor = new Color(1, 1, 1, 0);
        while (t < duration)
        {
            t += Time.deltaTime;
            solidColorImage.color = Color.Lerp(originalColor, targetColor, t / duration);
            yield return null;
        }
        solidColorImage.color = targetColor;
        solidColorImage.raycastTarget = false;
        solidColorImage.gameObject.SetActive(false);
    }

    public void ShowYouDiedPanel(string repeatSceneName)
    {
        retryButtonPressed = false;
        youDiedPanel.SetActive(true);
        StartCoroutine(FadeDiedScreen(repeatSceneName));
    }    

    IEnumerator FadeDiedScreen(string repeatSceneName)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(repeatSceneName);
        asyncLoad.allowSceneActivation = false;
        CanvasGroup canvasGroup = youDiedPanel.GetComponent<CanvasGroup>();
        float duration = 1f;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }
        yield return new WaitUntil(() => retryButtonPressed == true);
        Debug.Log("Retry button pressed, reloading scene.");
        asyncLoad.allowSceneActivation = true;
    }

    public void OnRetryButtonPressed()
    {
        youDiedPanel.SetActive(false);
        retryButtonPressed = true;
    }
}
