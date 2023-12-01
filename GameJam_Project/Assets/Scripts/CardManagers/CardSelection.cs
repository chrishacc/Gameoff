using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    //public ScrollRect scrollRect; // 引用滚动视图对象
    public Transform content; // 引用ScrollView中的Content对象
    public GameObject cardPrefab; // 卡牌预制体
    public int numCards = 10; // 卡牌数量
    //public ScrollRect scrollRect;

    private void Start()
    {
        // 设置Content的大小
        //RectTransform content = scrollRect.content;
        //content.sizeDelta = new Vector2(0, 1000);

        // 设置滚动视图的滚动范围
        //scrollRect.verticalNormalizedPosition = 1;
        //scrollRect.inertia = true;
        //scrollRect.decelerationRate = 0.5f;

        InitializeCards();
        // 在Start时选择第一个卡牌，你可以根据需要修改选择的逻辑
        SelectCard(content.GetChild(0).gameObject);
    }

    private void InitializeCards()
    {
        for (int i = 0; i < numCards; i++)
        {
            // 实例化卡牌并设置其父对象为Content
            GameObject card = Instantiate(cardPrefab, content);
            // 设置卡牌的位置，可以根据需要调整
            //card.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * 450, 0);
        }
    }

    private void SelectCard(GameObject card)
    {
        // 处理选中卡牌的逻辑，可以在这里实现卡牌的装备和卸下操作
        Debug.Log("Selected Card: " + card.name);
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    // 获取鼠标滚动的增量
    //    float scrollDelta = eventData.scrollDelta.x;

    //    // 在X轴上滚动
    //    scrollRect.horizontalNormalizedPosition -= scrollDelta * 0.01f;

    //    // 防止超出范围
    //    scrollRect.horizontalNormalizedPosition = Mathf.Clamp01(scrollRect.horizontalNormalizedPosition);
    //}
}
