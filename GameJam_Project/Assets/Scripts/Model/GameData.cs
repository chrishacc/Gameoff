using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public int turn;// 回合数
    public int faith;// 信仰值
    public int power;// 影响力
    public int numPeople;// 人口
    public int maxPeople;// 最大人口
    public int house;// 住房
    public int maxHouse;// 最大住房
    public int per_power;//
    private const int FaithPerTurn = 3;
    private const int MaxTurns = 50;
    private const int ThresholdBase = 4;

    private void Awake()
    {
        LoadGame();
    }

    #region 数据存储 DataSave
    private const string SaveFileName = "gameSave.json";


    // 在每回合结束时保存游戏状态
    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            Turn = turn,
            Faith = faith,
            Power = power,
            NumPeople = numPeople,
            MaxPeople = maxPeople,
            House = house,
            MaxHouse = maxHouse,
            Per_power = per_power
            // 可根据需要添加其他需要保存的数据
        };

        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(GetSaveFilePath(), jsonData);


    }

    // 在游戏启动时尝试加载存档
    public void LoadGame()
    {
        string filePath = GetSaveFilePath();

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);

            // 恢复游戏状态
            turn = saveData.Turn;
            faith = saveData.Faith;
            power = saveData.Power;
            numPeople = saveData.NumPeople;
            maxPeople = saveData.MaxPeople;
            house = saveData.House;
            maxHouse = saveData.MaxHouse;
            per_power = saveData.Per_power;
            // 可根据需要恢复其他数据
        }
    }

    // 获取存档文件路径
    private string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, SaveFileName);
    }
}
#endregion