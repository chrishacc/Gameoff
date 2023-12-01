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
                Debug.Log("按下了Esc,面板打开");

            }
            else
            {
                ExitPanel.SetActive(true);
                flag = true;
                Debug.Log("按下了Esc,面板关闭");

            }

        }
    }
}
