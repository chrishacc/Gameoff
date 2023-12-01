using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Model : MonoBehaviour
{
    private CardGenerate getCardScript; // ���ڱ��� GetCard �ű�������

    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    //public int Objecthp;
    public double pmata;
    
    void Start()
    {
        CardGenerate getCardScript = GameObject.FindObjectOfType<CardGenerate>();
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

            GameObject.Find("BattleController").GetComponent<BattleController>().mata -= cost;

            
            // ���GetCard�ű��Ƿ����
            if (getCardScript != null)
            {
                // ��ȡ�����������е�����
                int cardIndex = getCardScript.GetCardIndex(gameObject);

                // ����GetCard�ű��е�UseCard����
                getCardScript.UseCard(cardIndex);
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
