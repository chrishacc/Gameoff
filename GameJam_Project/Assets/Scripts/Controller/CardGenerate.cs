using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerate : MonoBehaviour
{
    public List<GameObject> playerHand;
    public List<GameObject> cardPrefabs;

    public Transform cardPosition1;
    public Transform cardPosition2;
    public Transform cardPosition3;

    // Start is called before the first frame update
    void Awake()
    {
        playerHand = new List<GameObject>();
        // 初始化玩家手牌
        DrawInitialCards();
    }

    // 初始化玩家手牌
    void DrawInitialCards()
    {
        for (int i = 0; i < 3; i++)
        {
            DrawCard();
        }
    }

    // 从牌库中抽取一张卡牌加入手牌
    void DrawCard()
    {
        int randomCardIndex = Random.Range(0, cardPrefabs.Count);
        GameObject newCard = Instantiate(cardPrefabs[randomCardIndex]);
        playerHand.Add(newCard);
        // 设置生成位置
        SetCardPosition(newCard, playerHand.Count - 1);
    }

    // 设置卡牌的生成位置
    void SetCardPosition(GameObject card, int index)
    {
        if (index == 0 && cardPosition1 != null)
        {
            card.transform.position = cardPosition1.position;
        }
        else if (index == 1 && cardPosition2 != null)
        {
            card.transform.position = cardPosition2.position;
        }
        else if (index == 2 && cardPosition3 != null)
        {
            card.transform.position = cardPosition3.position;
        }
        // 这里可以根据需要添加更多位置的判断
    }

    // 使用卡牌的方法
    public void UseCard(int cardIndex)
    {
        // 在实际游戏中，你可能会执行卡牌的效果，这里简单地销毁卡牌并抽取一张新的加入手牌
        Destroy(playerHand[cardIndex]);
        playerHand.RemoveAt(cardIndex);
        DrawCard();
    }

    // Update is called once per frame
    void Update()
    {
        // 在 Update 中监听用户输入等事件，以决定是否使用卡牌，这里仅作示例
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerHand.Count >= 1)
        {
            UseCard(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && playerHand.Count >= 2)
        {
            UseCard(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && playerHand.Count >= 3)
        {
            UseCard(2);
        }
    }
}
