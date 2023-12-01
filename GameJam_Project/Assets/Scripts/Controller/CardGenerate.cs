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
        // ��ʼ���������
        DrawInitialCards();
    }

    // ��ʼ���������
    void DrawInitialCards()
    {
        for (int i = 0; i < 3; i++)
        {
            DrawCard();
        }
    }

    // ���ƿ��г�ȡһ�ſ��Ƽ�������
    void DrawCard()
    {
        int randomCardIndex = Random.Range(0, cardPrefabs.Count);
        GameObject newCard = Instantiate(cardPrefabs[randomCardIndex]);
        playerHand.Add(newCard);
        // ��������λ��
        SetCardPosition(newCard, playerHand.Count - 1);
    }

    // ���ÿ��Ƶ�����λ��
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
        // ������Ը�����Ҫ��Ӹ���λ�õ��ж�
    }

    // ʹ�ÿ��Ƶķ���
    public void UseCard(int cardIndex)
    {
        // ��ʵ����Ϸ�У�����ܻ�ִ�п��Ƶ�Ч��������򵥵����ٿ��Ʋ���ȡһ���µļ�������
        Destroy(playerHand[cardIndex]);
        playerHand.RemoveAt(cardIndex);
        DrawCard();
    }

    // Update is called once per frame
    void Update()
    {
        // �� Update �м����û�������¼����Ծ����Ƿ�ʹ�ÿ��ƣ��������ʾ��
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
