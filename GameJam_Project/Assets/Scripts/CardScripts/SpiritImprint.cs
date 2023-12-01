using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SpiritImprint : MonoBehaviour
{
    private CardGenerate getCardScript; // ���ڱ��� GetCard �ű�������

    // Start is called before the first frame update
    public int id;
    public bool active;//0:unavailable.
    public int cost;
    public int dmg;
    //public int Objecthp;

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
            GameObject.Find("BattleController").GetComponent<BattleController>().spirit = 1;
            GameObject.Find("BattleController").GetComponent<BattleController>().spirit_time = 5;
            GameObject.Find("BattleController").GetComponent<BattleController>().Direct_Dmg(dmg,1);
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
