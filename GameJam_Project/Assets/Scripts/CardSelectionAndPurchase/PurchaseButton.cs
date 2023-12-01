using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    private int allfaithcost;
    private CardSAPManager a;
    public int nowcount;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("CardSAPManager").GetComponent<CardSAPManager>();

        allfaithcost = 0;
    }
    //购买按钮
    public void OnPurchaseClick()
    {

        for(int i = 0; i < a.selectedlist.Count; i++)
        {
            Debug.Log(a.selectedlist[i]);
            //计算当前选中的卡牌总花费
            if (a.isavaible[a.selectedlist[i]] == 0)
            {
                if (a.selectedlist[i] <= 16 && a.selectedlist[i] >= 7)
                {
                    allfaithcost += 20;
                }
                if(a.selectedlist[i] >= 17)
                {
                    allfaithcost += 200;
                }
                
            }
            a.SaveGame();
        }
        if (allfaithcost <= a.faith)
        {
            //购买选中的卡牌
            nowcount = a.selectedlist.Count;
            a.faith -= allfaithcost;
            for (int i = 0; i < nowcount; i++)
            {
                a.isavaible[a.selectedlist[0]] = 1;
                a.selectedlist.RemoveAt(0);
            }
            a.Update_Button();
            a.SaveGame();
            Debug.Log("购买成功");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
