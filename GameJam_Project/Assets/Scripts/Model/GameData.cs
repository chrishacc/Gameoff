using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
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

    private void Awake()
    {
        LoadGame();
    }

    #region ���ݴ洢 DataSave
    private const string SaveFileName = "gameSave.json";


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
#endregion