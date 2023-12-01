using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MindArrow : MonoBehaviour
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
        Debug.Log("MindArrow���Ʊ����");
        pmata = GameObject.Find("BattleController").GetComponent<BattleController>().mata;
        if (pmata >= cost)
        {
            Debug.Log("MindArrow���Ʊ����");
            GameObject.Find("BattleController").GetComponent<BattleController>().Direct_Dmg(5,1);
            GameObject.Find("BattleController").GetComponent<BattleController>().mata -= cost;

            CardGenerate getCardScript = GameObject.FindObjectOfType<CardGenerate>();
            // ���GetCard�ű��Ƿ����
            //if (getCardScript != null)
            //{
            //    // ��ȡ�����������е�����
            //    int cardIndex = getCardScript.GetCardIndex(gameObject);

            //    // ����GetCard�ű��е�UseCard����
            //    getCardScript.UseCard(cardIndex);
            //}
            GameObject.Find("CardGenerate").GetComponent<CardGenerate>().UseCard(id);
            //Destroy(this.gameObject);
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
