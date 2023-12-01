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
        // 创建GameManager实例
        gameManager = gameObject.AddComponent<GameManager>();

        // 订阅回合结束事件
        gameManager.TurnEnded += OnTurnEnded;

        // 订阅存档完成事件
        gameManager.SaveCompleted += OnSaveCompleted;

        // 尝试加载存档
        gameManager.LoadGame();

        //订阅建筑升级事件
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
        // 处理回合结束时的逻辑，例如更新UI显示等
        UpdateUI();

        // 在回合结束时保存游戏
        gameManager.SaveGame();
    }

    private void OnSaveCompleted()
    {
        // 存档完成时的逻辑
        gameManager.EncounterBoss();
    }


    // 在某个地方调用这个方法，表示当前回合结束
    public void EndTurn()
    {
        // 调用GameManager中的EndTurn方法
        gameManager.EndTurn();
    }

    private void UpdateUI()
    {
        // 更新显示信仰值、影响力、信徒数、信徒住房等UI元素
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
        // 更新显示信仰值、影响力、信徒数、信徒住房等UI元素
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
        // 更新显示信仰值、影响力、信徒数、信徒住房等UI元素
        faithText.text = $"Faith: {gameManager.Faith}+{gameManager.NumPeople}";
        powerText.text = $"Power: {gameManager.Power}";
        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";

    }

    private void OnLandmarkUpgradeUpdateUI()
    {
        // 更新显示信仰值、影响力、信徒数、信徒住房等UI元素
        faithText.text = $"Faith: {gameManager.Faith}+{gameManager.NumPeople}";
        powerText.text = $"Power: {gameManager.Power}";
        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";
    }

    private void OnAltarUpgradeUpdateUI()
    {
        // 更新显示信仰值、影响力、信徒数、信徒住房等UI元素
        faithText.text = $"Faith: {gameManager.Faith}+{gameManager.NumPeople}";
        powerText.text = $"Power: {gameManager.Power}";
        numPeopleText.text = $"People: {gameManager.NumPeople}/{gameManager.MaxPeople}";
        houseText.text = $"House: {gameManager.House}/{gameManager.MaxHouse}";
    }

}
