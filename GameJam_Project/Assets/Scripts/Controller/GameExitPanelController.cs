using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameExitPanelController : MonoBehaviour
{
    public GameObject ExitPanel;

    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        ExitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (flag)
            {
                ExitPanel.SetActive(false);
                flag = false;
                Debug.Log("������Esc,����");

            }
            else
            {
                ExitPanel.SetActive(true);
                flag = true;
                Debug.Log("������Esc,���ر�");

            }

        }
    }
}
