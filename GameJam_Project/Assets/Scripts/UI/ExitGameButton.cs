using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    public void ExitGame()
    {
        // 在这里编写退出游戏的代码
        Debug.Log("退出游戏"); // 这是一个可选的调试日志

        // 在编辑器中运行时，可以通过点击“Play”按钮退出游戏
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在构建应用程序时，可以使用以下代码退出游戏
        Application.Quit();
#endif
    }
}
