using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingUi : MonoBehaviour
{

    public Button settingButton;
    public Button closeButton;

    public Image background;

    public Slider mainSound;

    public Slider soundEffectSound;

    public Button toMenu;

    public Button quitGame;


    private void Start()
    {
        settingButton.onClick.AddListener(() => UiManager.Instance.PopUpSetMenu());

        closeButton.onClick.AddListener(() => UiManager.Instance.HideSetMenu());
        UiManager.Instance.HideSetMenu();
        mainSound.onValueChanged.AddListener(_ => SoundManager.Instance.MainSoundValue = mainSound.value);
        soundEffectSound.onValueChanged.AddListener(_ => SoundManager.Instance.SoundEffectValue = soundEffectSound.value);
        toMenu.onClick.AddListener(() => SceneLoader.Instance.LoadScene(0));
        quitGame.onClick.AddListener(() => Application.Quit());

    }




}
