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
        FadeInOut(true);
        var task = Task.Run(() => LoadingSceneProcess());
        task.Start();
    }
    private void LoadingSceneProcess()
    {
        loadingBar.fillAmount = 0;

        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            loadingBar.fillAmount = op.progress;
            text.text = ShowPercentage(op.progress);
            if (op.progress > 0.9f)
            {
                StartCoroutine(Fade(true));
            }
        }
    }

    private IEnumerator Fade(bool value)
    {
        yield return null;
        float timer = 0;
        float start = value ? 0 : 1;
        float goal = value ? 1 : 0;
        while (timer <= 1)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, goal, timer);
            yield return null;
        }
        if (!value)
        {
            gameObject.SetActive(false);
        }
    }

    private void FadeInOut(bool value)
    {
        float timer = 0;
        float start = value ? 0 : 1;
        float goal = value ? 1 : 0;
        while (timer <= 1)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, goal, timer);
        }
    }
    private string ShowPercentage(float value)
    {
        string tmp = value.ToString() + "%";
        return tmp;
    }

}
