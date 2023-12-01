//using UnityEngine;
//using UnityEngine.UI;

//public class UIView : MonoBehaviour
//{
//    public Text faithText;
//    public Text powerText;
//    public Text numPeopleText;
//    public Text houseText;

//    private GameManager gameManager;

//    private void Start()
//    {
//        // 获取GameManager实例
//        gameManager = FindObjectOfType<GameManager>();

//        // 订阅回合结束事件
//        gameManager.TurnEnded += OnTurnEnded;

//        // 更新UI显示
//        UpdateUI();
//    }

//    private void OnTurnEnded(GameManager gm)
//    {
//        // 回合结束时更新UI显示
//        UpdateUI();
//    }

//    public void UpdateUI()
//    {
//        // 更新显示信仰值、影响力、信徒数、信徒住房等UI元素
//        faithText.text = $"Faith: {gameManager.Faith}";
//        powerText.text = $"Power: {gameManager.Power}";
//        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
//        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";
//    }
//}
