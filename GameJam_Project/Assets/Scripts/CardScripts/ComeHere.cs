using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ComeHere : MonoBehaviour
{
    private CardGenerate getCardScript; // ���ڱ��� GetCard �ű�������

    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    

    public double pmata;
    // Start is called before the first frame update
    void Start()
    {
        CardGenerate getCardScript = GameObject.FindObjectOfType<CardGenerate>();
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
                //GameObject.Find("BattleController").GetComponent<BattleController>().Add_Fols(3);

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
