using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelButton : MonoBehaviour
{
    public GameObject panel; 

    // 在按钮点击时调用此方法
    public void Panel()
    {
        // 检查Panel的当前状态
        if (panel.activeSelf)
        {
            // 如果Panel当前处于激活状态，则禁用它
            panel.SetActive(false);
            Debug.Log("Panel is closed");
        }
        else
        {
            // 如果Panel当前处于禁用状态，则激活它
            panel.SetActive(true);
        }
    }
}
