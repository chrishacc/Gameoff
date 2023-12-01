using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CardSAPManager : MonoBehaviour
{
    public int[] isavaible;//�����Ҫ���л��洢����¼��Щ�����Ѿ��������ˡ�
    public int ifselected;
    public List<int> selectedlist;
    
    private const string SaveFileName = "gameSave.json";
    [SerializeField] private TextMeshProUGUI FaithText;
    private GameObject thisbutton;
    
    public int faith;
    public int turn;
    public int power;
    public int house;
    public int numPeople;
    public int maxPeople;
    public int maxHouse;
    public int per_power;
    //public List<int> purchaselist;
    //public int if
    void Awake()
    {
        LoadGame();
        LoadCard();
        isavaible = new int[30];//1���ã�0������
        selectedlist = new List<int>();
        FaithText.text = $"Now Faith:  {faith.ToString()}";
        //nowfaith=

        Update_Button();
        
    }

    //IsAvailable��Ҫ���л������
    #region �����ļ��洢���ȡ
    private string GetCardFilePath()
    {
        return Path.Combine(Application.persistentDataPath, "CardData.json");
    }

    public void LoadCard()
    {
        string filePath = GetCardFilePath();

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            int[] IsAvailable = JsonUtility.FromJson<int[]>(jsonData);

            // �ָ���Ϸ״̬

            isavaible = IsAvailable;
            // �ɸ�����Ҫ�ָ���������
        }
    }

    public void SaveCard()
    {
        

        string jsonData = JsonUtility.ToJson(isavaible);
        File.WriteAllText(GetCardFilePath(), jsonData);

        // ֪ͨ�浵���
        //SaveCompleted?.Invoke();
    }

    #endregion

    private string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, SaveFileName);
    }
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
        //SaveCompleted?.Invoke();
    }
    void Update()
    {
        FaithText.text = $"Now Faith:  {faith.ToString()}";
    }

    public void Update_Button()//����ÿ�������Ƿ��ѹ���
    {
        for(int i = 1; i <= 20; i++)
        {
            thisbutton = GameObject.Find($"Button ({(i-1).ToString()})") ;
            Debug.Log($"Button ({(i - 1).ToString()})");
            if (isavaible[i] == 0)
            {
                thisbutton.GetComponent<Image>().color = new(200 / 255f, 255 / 255f, 200 / 255f);
            }
        }
        SaveCard();
    }
}
