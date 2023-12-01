using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndButton : MonoBehaviour
{
    public GameController gameController;

    public void EndTurn()
    {
        // ����GameController�е�EndTurn����
        gameController.EndTurn();

        AudioManager.Instance.PlaySound("onbutton");
    }
}
