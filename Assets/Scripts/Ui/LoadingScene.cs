using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    [SerializeField] private Image background;

    [SerializeField] private Image loadingBar;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CanvasGroup canvasGroup;

    private int index;


    private void Awake()
    {
        gameObject.SetActive(false);
    }


    public void LoadScene(int sceneIndex)
    {
        gameObject.SetActive(true);
        index = sceneIndex;
        StartCoroutine(Fade(true));
        //var t = LoadSceneProcess();
    }

    private IEnumerator LoadingSceneProcess()
    {
        yield return null;
        loadingBar.fillAmount = 0;

        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            yield return null;
            loadingBar.fillAmount = op.progress;
            text.text = ShowPercentage(op.progress);
            if (op.progress >= 0.9f)
            {
                op.allowSceneActivation = true;
                StartCoroutine(Fade(false));
                UiManager.Instance.HideSetMenu();
            }
        }
    }


    private IEnumerator Fade(bool value)
    {
        yield return null;
        float timer = value ? 1 : 0;
        float start = value ? 0 : 1;
        float end = value ? 1 : 0;
        while (timer <= 1)
        {
            yield return null;
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, timer);
        }
        if (!value)
        {
            gameObject.SetActive(false);
            loadingBar.fillAmount = 0;
            text.text = null;
        }
        else
        {
            StartCoroutine(LoadingSceneProcess());
        }
    }
    private string ShowPercentage(float value)
    {
        string tmp = (100 * value).ToString() + "%";
        return tmp;
    }


}
