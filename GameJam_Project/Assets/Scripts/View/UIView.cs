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
//        // ��ȡGameManagerʵ��
//        gameManager = FindObjectOfType<GameManager>();

//        // ���ĻغϽ����¼�
//        gameManager.TurnEnded += OnTurnEnded;

//        // ����UI��ʾ
//        UpdateUI();
//    }

//    private void OnTurnEnded(GameManager gm)
//    {
//        // �غϽ���ʱ����UI��ʾ
//        UpdateUI();
//    }

//    public void UpdateUI()
//    {
//        // ������ʾ����ֵ��Ӱ��������ͽ������ͽס����UIԪ��
//        faithText.text = $"Faith: {gameManager.Faith}";
//        powerText.text = $"Power: {gameManager.Power}";
//        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
//        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";
//    }
//}
