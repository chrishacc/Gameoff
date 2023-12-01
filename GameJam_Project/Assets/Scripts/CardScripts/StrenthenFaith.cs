using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StrenthenFaith : MonoBehaviour
{

    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    //public int Objecthp;

    public double pmata;

    void Start()
    {
 

    }

    private void OnMouseUp()
    {
        OnPointerClick();
    }

    public void OnPointerClick()
    {
        Debug.Log("该卡牌被点击触发");
        pmata = GameObject.Find("BattleController").GetComponent<BattleController>().mata;
        if (pmata >= cost)
        {
            GameObject.Find("BattleController").GetComponent<BattleController>().magnif_time = 3;
            GameObject.Find("BattleController").GetComponent<BattleController>().magnif = 1.5;
            GameObject.Find("BattleController").GetComponent<BattleController>().mata -= cost;

            GameObject.Find("CardGenerate").GetComponent<CardGenerate>().UseCard(id);
        }
        else
        {
            //mata not enough
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
