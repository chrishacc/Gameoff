using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ComeHere : MonoBehaviour
{
    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    

    public double pmata;
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
        if (pmata >= cost)
        {
            if (GameObject.Find("BattleController").GetComponent<BattleController>().memnum >= 3)
            {
                GameObject.Find("BattleController").GetComponent<BattleController>().Add_Fols(3);

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
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}