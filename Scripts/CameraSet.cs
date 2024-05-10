using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    private Camera cam_SingleScreen;
    public Camera cam_DoubleScreen_01;
    public Camera cam_DoubleScreen_02;
    public bool debugDualScreenOnSingleDisplay = false; // 调试标志
    public static bool UseDoubleScreen = false;

    private void Awake()
    {
        cam_SingleScreen = Camera.main;
        cam_SingleScreen.gameObject.SetActive(false);
        bool isDualScreenEnabled = PlayerPrefs.GetInt("IsDualScreenEnabled", 0) == 1;
        bool activateDualScreens = isDualScreenEnabled && (Display.displays.Length > 1 || debugDualScreenOnSingleDisplay);

        if (activateDualScreens || debugDualScreenOnSingleDisplay)
        {
            // 激活第二个显示器，如果有的话
            if (Display.displays.Length > 1)
            {
                Display.displays[1].Activate();
            }
            UseDoubleScreen = true;

            // 禁用单屏相机
            cam_SingleScreen.gameObject.SetActive(false);

            cam_DoubleScreen_01.gameObject.SetActive(true);
            cam_DoubleScreen_02.gameObject.SetActive(true);
        }
        else
        {
            UseDoubleScreen = false;
            // 使用单屏相机
            cam_SingleScreen.gameObject.SetActive(true);
            cam_DoubleScreen_01.gameObject.SetActive(false);
            cam_DoubleScreen_02.gameObject.SetActive(false);
        }
    }
}


