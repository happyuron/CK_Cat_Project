using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{

    public LoadingScene sceneLoad;

    protected override void Awake()
    {
        base.Awake();
    }

    public void LoadScene(int sceneIndex)
    {
        sceneLoad.LoadScene(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }
}
