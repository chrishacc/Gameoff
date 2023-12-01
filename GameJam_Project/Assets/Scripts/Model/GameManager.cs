using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour
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

    public int Turn { get { return turn; } }
    public int Faith { get { return faith; } }
    public int Power { get { return power; } }
    public int NumPeople { get { return numPeople; } }
    public int MaxPeople { get { return maxPeople; } }
    public int House { get { return house; } }
    public int MaxHouse { get { return maxHouse; } }

    
    public GameManager()
    {
        // 初始化游戏状态
        turn = 1;
        faith = 8;
        power = 0;
        numPeople = 3;
        maxPeople = 20;
        house = 5;
        maxHouse = 20;
        per_power = 0;
    }

    public event Action<GameManager> TurnEnded;// 回合结束事件
    public void EndTurn()
    {
        // 结算信仰值、影响力等
        faith += numPeople + FaithPerTurn;
        power += per_power;
        if (power >= CalculatePowerThreshold() && numPeople < house)
        {
            numPeople++;
            power = 0;
        }
        turn++;
        // 触发回合结束事件
        TurnEnded?.Invoke(this);
    }

    private int CalculatePowerThreshold() 
    {
        return ThresholdBase + (int)Math.Ceiling((double)numPeople / 3);
    }

    //判断是否遭遇Boss
    public void EncounterBoss()
    {
        if(turn == 20)
        {
            SceneManager.LoadScene("BattleScene01");
        }
        else if(turn == 38)
        {
            SceneManager.LoadScene("BattleScene02");
        }
        else if(turn == 50)
        {
            SceneManager.LoadScene("BattleScene03");
        }
    }

    //未使用
    #region 建筑升级效果
    // 信徒住所升级效果
    public void OnDiscipleResidenceUpgrade()
    {
        //faith -= 20;
        //其他效果

    }

    public void OnLandmarkUpgrade()
    {
        //faith -= 20;
        //其他效果

    }

    public void OnAltarUpgrade()
    {
        //faith -= 20;
        //其他效果

    }

    #endregion

    #region 数据存储 DataSave
    private const string SaveFileName = "gameSave.json";

    // 事件通知存档完成
    public event Action SaveCompleted;// 存档完成事件

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

        // 通知存档完成
        SaveCompleted?.Invoke();
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

[Serializable]
public class SaveData
{
    public int Turn;
    public int Faith;
    public int Power;
    public int NumPeople;
    public int MaxPeople;
    public int House;
    public int MaxHouse;
    public int Per_power;
    // 可根据需要添加其他需要保存的数据
}
#endregion
