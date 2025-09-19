using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] private Image fadeImage;         // Full-screen black UI Image
    [SerializeField] private float fadeDuration = 1f; // Fade in/out duration

    [Header("Next Scene")]
    [SerializeField] private string nextSceneName = "SampleScene";

    private void Start()
    {
        // Attempt to auto-find fade image if not assigned
        if (fadeImage == null)
            fadeImage = FindFadeImage();

        if (fadeImage == null)
        {
            Debug.LogError("FadeImage not assigned and no suitable Image found in the scene.");
            return;
        }

        // Start fully black
        SetFadeAlpha(1f);

        // Fade in
        StartCoroutine(FadeIn());
    }

    /// <summary>
    /// Called by UI button to start the game.
    /// </summary>
    public void OnStartButtonClicked()
    {
        if (fadeImage == null)
        {
            Debug.LogError("FadeImage is missing!");
            return;
        }

        StartCoroutine(FadeOutAndLoadScene());
    }

    #region Fade Coroutines
    private IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SetFadeAlpha(0f);
    }

    private IEnumerator FadeOutAndLoadScene()
    {
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SetFadeAlpha(1f);
        SceneManager.LoadScene(nextSceneName);
    }
    #endregion

    #region Utility Methods
    private void SetFadeAlpha(float alpha)
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = Mathf.Clamp01(alpha);
            fadeImage.color = c;
        }
    }

    private Image FindFadeImage()
    {
        // Try to find by name
        GameObject go = GameObject.Find("FadeImage");
        if (go != null)
            return go.GetComponent<Image>();

        // Otherwise, search all images in the scene containing "fade" in their name
        foreach (var img in Object.FindObjectsByType<Image>(FindObjectsSortMode.None))
        {
            if (img != null && img.gameObject.name.ToLower().Contains("fade"))
                return img;
        }

        return null;
    }
    #endregion
}
