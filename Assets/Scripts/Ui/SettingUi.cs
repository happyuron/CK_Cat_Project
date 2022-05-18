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


    private void Start()
    {
        UiManager.Instance.settingButton = settingButton;
        settingButton.onClick.AddListener(() => UiManager.Instance.PopUpSetMenu());

        closeButton.onClick.AddListener(() => UiManager.Instance.HideSetMenu());
        UiManager.Instance.HideSetMenu();
        mainSound.onValueChanged.AddListener(_ => SoundManager.Instance.mainSoundValue = mainSound.value);
        soundEffectSound.onValueChanged.AddListener(_ => SoundManager.Instance.soundEffectValue = soundEffectSound.value);

    }



}
