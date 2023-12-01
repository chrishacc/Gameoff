using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Contemplation : MonoBehaviour
{
    private CardGenerate getCardScript; // 用于保存 GetCard 脚本的引用

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

    public void OnPointerClick()
    {
        pmata = GameObject.Find("BattleController").GetComponent<BattleController>().mata;
        if (pmata >= cost)
        {
            GameObject.Find("BattleController").GetComponent<BattleController>().magic_dmg = 2;
            GameObject.Find("BattleController").GetComponent<BattleController>().magic_dmg_time = 4;

            GameObject.Find("BattleController").GetComponent<BattleController>().mata -= cost;

            
            // 检查GetCard脚本是否存在
            if (getCardScript != null)
            {
                // 获取卡牌在手牌中的索引
                int cardIndex = getCardScript.GetCardIndex(gameObject);

                // 调用GetCard脚本中的UseCard方法
                getCardScript.UseCard(cardIndex);
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
