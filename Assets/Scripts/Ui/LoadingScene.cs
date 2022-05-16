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


    private RectTransform rectTr;

    private int index;


    private void Awake()
    {
        gameObject.SetActive(false);
        rectTr = background.rectTransform;
    }


    public void LoadScene(int sceneIndex)
    {
        index = sceneIndex;
        gameObject.SetActive(true);
        StartCoroutine(HorizontalMove(0));
    }

    public IEnumerator HorizontalMove(int value)
    {
        yield return null;
        float setX = value == 1 ? -1920 : 1920;
        float dirX = value == 1 ? 1920 : -1920;
        rectTr.localPosition = new Vector3(setX, 0, 0);
        Vector2 dirVec = new Vector2(dirX, 0);


        while (true)
        {
            yield return null;
            rectTr.localPosition = Vector2.MoveTowards(rectTr.localPosition, dirVec, 50);
            if (Vector2.Distance(rectTr.localPosition, new Vector2(0, 0)) <= 60)
            {
                AsyncOperation op = SceneManager.LoadSceneAsync(index);
                op.allowSceneActivation = false;
                while (!op.isDone)
                {
                    yield return null;
                    if (op.progress >= 0.9f)
                    {
                        op.allowSceneActivation = true;
                    }
                }

            }
            if (Vector2.Distance(rectTr.localPosition, dirVec) < 10)
            {
                gameObject.SetActive(false);
                //UiManager.Instance.HideSetMenu();
                break;
            }
        }

    }

}
