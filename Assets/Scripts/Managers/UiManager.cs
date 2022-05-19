using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : Singleton<UiManager>
{
    public Button settingButton;
    public SettingUi settingUi;

    public GameObject settingUiObject;

    public ClearUi clearUi;

    public Vector2 GetMousePos()
    {
        Vector2 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return tmp;
    }

    public void PopUpSetMenu()
    {
        settingButton.gameObject.SetActive(false);
        settingUi.gameObject.SetActive(true);
    }

    public void HideSetMenu()
    {
        settingButton.gameObject.SetActive(StageManager.Instance.showSettingButton);
        settingUiObject.SetActive(StageManager.Instance.showSettingButton);
        settingUi.gameObject.SetActive(false);
    }
    public void HideAllSetMenu()
    {
        settingUi.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        settingUiObject.SetActive(false);

    }

    public void PopUpClearUi()
    {
        clearUi.Clear();
    }



}