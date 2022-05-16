using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : Singleton<UiManager>
{
    public Button settingButton;
    public SettingUi settingUi;
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
        settingUi.gameObject.SetActive(false);
    }





}