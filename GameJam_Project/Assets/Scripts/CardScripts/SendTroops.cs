using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SendTroops : MonoBehaviour
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

    public void OnPointerClick()
    {
        pmata = GameObject.Find("BattleController").GetComponent<BattleController>().mata;
        if (pmata >= cost)
        {
            if(GameObject.Find("BattleController").GetComponent<BattleController>().memnum >= 1)
            {
                GameObject.Find("BattleController").GetComponent<BattleController>().Add_Fols(1);

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
