using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearUi : MonoBehaviour
{
    public Button restart;

    public Button toMenu;

    private void Awake()
    {
        toMenu.onClick.AddListener(() => SceneLoad(0));
        restart.onClick.AddListener(() => SceneLoad(1));
        gameObject.SetActive(false);
    }

    public void SceneLoad(int index)
    {
        HideUi();
        SceneLoader.Instance.LoadScene(index);
    }


    public void Clear()
    {
        gameObject.SetActive(true);
    }

    public void HideUi()
    {
        gameObject.SetActive(false);
    }

}
