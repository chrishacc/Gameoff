using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public GameManager gameManager;
    public BuildingController buildingController;

    //public UIView uiView;
    
    [SerializeField] private TextMeshProUGUI faithText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI numPeopleText;
    [SerializeField] private TextMeshProUGUI houseText;
    [SerializeField] private TextMeshProUGUI nextTurnText;


    private void Awake()
    {
        // ����GameManagerʵ��
        gameManager = gameObject.AddComponent<GameManager>();

        // ���ĻغϽ����¼�
        gameManager.TurnEnded += OnTurnEnded;

        // ���Ĵ浵����¼�
        gameManager.SaveCompleted += OnSaveCompleted;

        // ���Լ��ش浵
        gameManager.LoadGame();

        //���Ľ��������¼�
        buildingController.OnDiscipleResidenceUpgrade += OnDiscipleResidenceUpgrade;
        buildingController.OnLandmarkUpgrade += OnLandmarkUpgrade;
        buildingController.OnAltarUpgrade += OnAltarUpgrade;

        
    }
   

    private void Start()
    {
        
        OnBeginUpdateUI();
    }

    private void OnTurnEnded(GameManager gm)
    {
        // ����غϽ���ʱ���߼����������UI��ʾ��
        UpdateUI();

        // �ڻغϽ���ʱ������Ϸ
        gameManager.SaveGame();
    }

    private void OnSaveCompleted()
    {
        // �浵���ʱ���߼�
        gameManager.EncounterBoss();
    }


    // ��ĳ���ط����������������ʾ��ǰ�غϽ���
    public void EndTurn()
    {
        // ����GameManager�е�EndTurn����
        gameManager.EndTurn();
    }

    private void UpdateUI()
    {
        // ������ʾ����ֵ��Ӱ��������ͽ������ͽס����UIԪ��
        faithText.text = $"Faith: {gameManager.Faith}+{3+gameManager.NumPeople}";
        powerText.text = $"Power: {gameManager.Power}";
        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";
        if(gameManager.Turn < 20)
            nextTurnText.text = $"There are: {20 - gameManager.Turn} rounds of war";
        else if(gameManager.Turn < 38)
            nextTurnText.text = $"There are: {38 - gameManager.Turn} rounds of war";
        else
        nextTurnText.text = $"There are: {50 - gameManager.Turn} rounds of war";
    }

    private void OnBeginUpdateUI()
    {
        // ������ʾ����ֵ��Ӱ��������ͽ������ͽס����UIԪ��
        faithText.text = $"Faith: {gameManager.Faith}+{gameManager.NumPeople}";
        powerText.text = $"Power: {gameManager.Power}";
        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";
        if (gameManager.Turn < 20)
            nextTurnText.text = $"There are: {20 - gameManager.Turn} rounds of war";
        else if (gameManager.Turn < 38)
            nextTurnText.text = $"There are: {38 - gameManager.Turn} rounds of war";
        else
            nextTurnText.text = $"There are: {50 - gameManager.Turn} rounds of war";
    }

    private void OnDiscipleResidenceUpgrade()
    {
        gameManager.OnDiscipleResidenceUpgrade();
        OnDiscipleResidenceUpgradeUpdateUI();
        gameManager.SaveGame();
    }

    private void OnLandmarkUpgrade()
    {
        gameManager.OnLandmarkUpgrade();
        OnLandmarkUpgradeUpdateUI();
        gameManager.SaveGame();
    }

    private void OnAltarUpgrade()
    {
        gameManager.OnAltarUpgrade();
        OnAltarUpgradeUpdateUI();
        gameManager.SaveGame();
    }


    private void OnDiscipleResidenceUpgradeUpdateUI()
    {
        // ������ʾ����ֵ��Ӱ��������ͽ������ͽס����UIԪ��
        faithText.text = $"Faith: {gameManager.Faith}+{gameManager.NumPeople}";
        powerText.text = $"Power: {gameManager.Power}";
        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";

    }

    private void OnLandmarkUpgradeUpdateUI()
    {
        // ������ʾ����ֵ��Ӱ��������ͽ������ͽס����UIԪ��
        faithText.text = $"Faith: {gameManager.Faith}+{gameManager.NumPeople}";
        powerText.text = $"Power: {gameManager.Power}";
        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";
    }

    private void OnAltarUpgradeUpdateUI()
    {
        // ������ʾ����ֵ��Ӱ��������ͽ������ͽס����UIԪ��
        faithText.text = $"Faith: {gameManager.Faith}+{gameManager.NumPeople}";
        powerText.text = $"Power: {gameManager.Power}";
        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";
    }

}
