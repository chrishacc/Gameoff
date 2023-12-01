using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectionButton : MonoBehaviour
{
    public int buttonid;
    public int purchase_cost;
    public int ifsel;
    private List<int> thislist;
    public Image thisimage;
    private CardSAPManager a;
    private void Start()
    {
        ifsel = 0;
        a = GameObject.Find("CardSAPManager").GetComponent<CardSAPManager>();
        thislist = a.selectedlist;
        //thisimage = GetComponent<Image>();
    }
    public void Onclick()
    {
        if (ifsel == 0)
        {
            ifsel = 1;
            thisimage.color = new(200 / 255f, 200 / 255f, 255 / 255f);//选中的效果
            thislist.Add(buttonid);
        }
        else
        {
            ifsel = 0;
            if (a.isavaible[buttonid] == 1)
            {
                thisimage.color = new(255 / 255f, 255 / 255f, 255 / 255f);
            }
            
            else
            {
                thisimage.color = new(200 / 255f, 255 / 255f, 200 / 255f);
            }
            thislist.Remove(buttonid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((!thislist.Contains(buttonid)) && ifsel == 1)
        {
            ifsel = 0;
            thisimage.color = new(255, 255, 255);
        }
    }
}
