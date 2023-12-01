using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelButton : MonoBehaviour
{
    public GameObject panel; 

    // �ڰ�ť���ʱ���ô˷���
    public void Panel()
    {
        // ���Panel�ĵ�ǰ״̬
        if (panel.activeSelf)
        {
            // ���Panel��ǰ���ڼ���״̬���������
            panel.SetActive(false);
            Debug.Log("Panel is closed");
        }
        else
        {
            // ���Panel��ǰ���ڽ���״̬���򼤻���
            panel.SetActive(true);
        }
    }
}
