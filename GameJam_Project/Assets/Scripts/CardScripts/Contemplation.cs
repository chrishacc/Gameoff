using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Contemplation : MonoBehaviour
{
    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    //public int Objecthp;

    public double pmata;
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
            GameObject.Find("BattleController").GetComponent<BattleController>().magic_dmg = 2;
            GameObject.Find("BattleController").GetComponent<BattleController>().magic_dmg_time = 4;

            GameObject.Find("BattleController").GetComponent<BattleController>().mata -= cost;

            GameObject.Find("CardGenerate").GetComponent<CardGenerate>().UseCard(id);
        }
        else
        {
            //mata not enough
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
