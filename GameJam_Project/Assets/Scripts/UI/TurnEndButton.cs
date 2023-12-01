using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndButton : MonoBehaviour
{
    public GameController gameController;

    public void EndTurn()
    {
        // 调用GameController中的EndTurn方法
        gameController.EndTurn();

        AudioManager.Instance.PlaySound("onbutton");
    }
}
