using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Create : MonoBehaviour
{
    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    

    public double pmata;
    public int house;
    public int peo;
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
            
            //GameObject.Find("BattleControllerObject").GetComponent<BattleController>().
            peo = GameObject.Find("GameData").GetComponent<GameData>().numPeople;
            house = GameObject.Find("GameData").GetComponent<GameData>().maxPeople;
            if (peo < house)
            {
                GameObject.Find("BattleController").GetComponent<BattleController>().memnum+=1;
                GameObject.Find("GameData").GetComponent<GameData>().numPeople+=1;
                GameObject.Find("BattleController").GetComponent<BattleController>().mata -= cost;

                GameObject.Find("CardGenerate").GetComponent<CardGenerate>().UseCard(id);
            }
            else
            {
                //house not enough
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
