using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour
{
    public int turn;// �غ���
    public int faith;// ����ֵ
    public int power;// Ӱ����
    public int numPeople;// �˿�
    public int maxPeople;// ����˿�
    public int house;// ס��
    public int maxHouse;// ���ס��
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
        // ��ʼ����Ϸ״̬
        turn = 1;
        faith = 8;
        power = 0;
        numPeople = 3;
        maxPeople = 20;
        house = 5;
        maxHouse = 20;
        per_power = 0;
    }

    public event Action<GameManager> TurnEnded;// �غϽ����¼�
    public void EndTurn()
    {
        // ��������ֵ��Ӱ������
        faith += numPeople + FaithPerTurn;
        power += per_power;
        if (power >= CalculatePowerThreshold() && numPeople < house)
        {
            numPeople++;
            power = 0;
        }
        turn++;
        // �����غϽ����¼�
        TurnEnded?.Invoke(this);
    }

    private int CalculatePowerThreshold() 
    {
        return ThresholdBase + (int)Math.Ceiling((double)numPeople / 3);
    }

    //�ж��Ƿ�����Boss
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

    //δʹ��
    #region ��������Ч��
    // ��ͽס������Ч��
    public void OnDiscipleResidenceUpgrade()
    {
        //faith -= 20;
        //����Ч��

    }

    public void OnLandmarkUpgrade()
    {
        //faith -= 20;
        //����Ч��

    }

    public void OnAltarUpgrade()
    {
        //faith -= 20;
        //����Ч��

    }

    #endregion

    #region ���ݴ洢 DataSave
    private const string SaveFileName = "gameSave.json";

    // �¼�֪ͨ�浵���
    public event Action SaveCompleted;// �浵����¼�

    // ��ÿ�غϽ���ʱ������Ϸ״̬
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
            // �ɸ�����Ҫ���������Ҫ���������
        };

        string jsonData = JsonUtility.ToJson(saveData);
        File.WriteAllText(GetSaveFilePath(), jsonData);

        // ֪ͨ�浵���
        SaveCompleted?.Invoke();
    }

    // ����Ϸ����ʱ���Լ��ش浵
    public void LoadGame()
    {
        string filePath = GetSaveFilePath();

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);

            // �ָ���Ϸ״̬
            turn = saveData.Turn;
            faith = saveData.Faith;
            power = saveData.Power;
            numPeople = saveData.NumPeople;
            maxPeople = saveData.MaxPeople;
            house = saveData.House;
            maxHouse = saveData.MaxHouse;
            per_power = saveData.Per_power;
            // �ɸ�����Ҫ�ָ���������
        }
    }

    // ��ȡ�浵�ļ�·��
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
    // �ɸ�����Ҫ���������Ҫ���������
}
#endregion
