using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BloodExplotion : MonoBehaviour
{
    
    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    

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
        pmata = GameObject.Find("BattleController").GetComponent<BattleController>().mata;
        if (pmata >= cost)
        {
            GameObject.Find("BattleController").GetComponent<BattleController>().Direct_Dmg
                (GameObject.Find("BattleController").GetComponent<BattleController>().batnum*5,1);
            GameObject.Find("BattleController").GetComponent<BattleController>().Add_Fols(0);
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
