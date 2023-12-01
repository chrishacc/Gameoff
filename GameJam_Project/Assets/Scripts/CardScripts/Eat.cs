using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Eat : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    //public int Objecthp;

    private double pmata;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
 

    }
    private void OnMouseUp()
    {
        OnPointerClick();
    }


    public void OnPointerClick()
    {
        pmata = GameObject.Find("BattleController").GetComponent<BattleController>().mata;
        if (pmata >= cost)
        {
            num = GameObject.Find("BattleController").GetComponent<BattleController>().memnum;
            if (num >= 1)
            {
                GameObject.Find("BattleController").GetComponent<BattleController>().memnum -= 1;
                GameObject.Find("BattleController").GetComponent<BattleController>().Change_HP(5,0);
                GameObject.Find("BattleController").GetComponent<BattleController>().mata -= cost;

                GameObject.Find("CardGenerate").GetComponent<CardGenerate>().UseCard(id);
            }
            else
            {
                //memnum not enough
            }
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
