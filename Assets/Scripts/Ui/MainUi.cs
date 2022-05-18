using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUi : MonoBehaviour
{
    public Button startButton;

    private void Awake()
    {
        startButton.onClick.AddListener(() => SceneLoader.Instance.LoadScene(1));
    }

}
