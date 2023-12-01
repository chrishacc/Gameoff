using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BloodSacrifice : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    //public int Objecthp;

    public double pmata;
    private int num;
    // Start is called before the first frame update
    void Start()
    {


    }

    private void OnMouseUp()
    {
        OnPointerClick();
    }

    // Start is called before the first frame update

    public void OnPointerClick()
    {
        pmata = GameObject.Find("BattleController").GetComponent<BattleController>().mata;
        num = GameObject.Find("BattleController").GetComponent<BattleController>().memnum;
        if (pmata >= cost)
        {
            if (num >= 1)
            {
                GameObject.Find("BattleController").GetComponent<BattleController>().memnum -= 1;
                GameObject.Find("BattleController").GetComponent<BattleController>().Add_Dmg(1);
                GameObject.Find("BattleController").GetComponent<BattleController>().mata -= cost;

                GameObject.Find("CardGenerate").GetComponent<CardGenerate>().UseCard(id);
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
