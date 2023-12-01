using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    //public ScrollRect scrollRect; // ���ù�����ͼ����
    public Transform content; // ����ScrollView�е�Content����
    public GameObject cardPrefab; // ����Ԥ����
    public int numCards = 10; // ��������
    //public ScrollRect scrollRect;

    private void Start()
    {
        // ����Content�Ĵ�С
        //RectTransform content = scrollRect.content;
        //content.sizeDelta = new Vector2(0, 1000);

        // ���ù�����ͼ�Ĺ�����Χ
        //scrollRect.verticalNormalizedPosition = 1;
        //scrollRect.inertia = true;
        //scrollRect.decelerationRate = 0.5f;

        InitializeCards();
        // ��Startʱѡ���һ�����ƣ�����Ը�����Ҫ�޸�ѡ����߼�
        SelectCard(content.GetChild(0).gameObject);
    }

    private void InitializeCards()
    {
        for (int i = 0; i < numCards; i++)
        {
            // ʵ�������Ʋ������丸����ΪContent
            GameObject card = Instantiate(cardPrefab, content);
            // ���ÿ��Ƶ�λ�ã����Ը�����Ҫ����
            //card.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * 450, 0);
        }
    }

    private void SelectCard(GameObject card)
    {
        // ����ѡ�п��Ƶ��߼�������������ʵ�ֿ��Ƶ�װ����ж�²���
        Debug.Log("Selected Card: " + card.name);
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    // ��ȡ������������
    //    float scrollDelta = eventData.scrollDelta.x;

    //    // ��X���Ϲ���
    //    scrollRect.horizontalNormalizedPosition -= scrollDelta * 0.01f;

    //    // ��ֹ������Χ
    //    scrollRect.horizontalNormalizedPosition = Mathf.Clamp01(scrollRect.horizontalNormalizedPosition);
    //}
}
