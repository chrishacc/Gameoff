using System;
using System.IO;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private BuildingModel buildingModel;

    // �������ݸ����¼�
    public event Action<BuildingData> OnBuildingUpdated;

    private void Awake()
    {
        buildingModel = new BuildingModel();
    }

    #region ��ȡ��������
    // ��ȡ��ǰ��������
    public BuildingData GetBuildingData(string buildingName)
    {
        return buildingModel.GetBuildingData(buildingName);
    }

    public DiscipleResidenceData LoadDiscipleResidenceData(string buildingName)
    {
        DiscipleResidenceData DiscipleResidenceData = LoadDiscipleResidenceDataFromFile(buildingName);
        return DiscipleResidenceData as DiscipleResidenceData;
    }

    public LandmarkData LoadLandmarkData(string buildingName)
    {
        LandmarkData LandmarkData = LoadLandmarkDataFromFile(buildingName);
        return LandmarkData as LandmarkData;
    }

    public StatueData LoadStatueData(string buildingName)
    {
        StatueData StatueData = LoadStatueDataFromFile(buildingName);
        return StatueData as StatueData;
    }

    public AltarData LoadAltarData(string buildingName)
    {
        AltarData AltarData = LoadAltarDataFromFile(buildingName);
        return AltarData as AltarData;
    }
    #endregion

    #region ��������

    public event Action OnBuildingUpgrade;
    // ���������ȼ�
    public void UpgradeBuilding(string buildingName)
    {
        BuildingData buildingData = buildingModel.GetBuildingData(buildingName);
        buildingData.Upgrade();
        SaveBuildingData(buildingData);
    }

    public event Action OnDiscipleResidenceUpgrade;// ��ͽס�������¼�
    public void UpgradeDiscipleResidence(string buildingName)
    {
        DiscipleResidenceData DiscipleResidenceData = LoadDiscipleResidenceData(buildingName);
        DiscipleResidenceData.Upgrade();
        OnDiscipleResidenceUpgrade?.Invoke();
        SaveBuildingData(DiscipleResidenceData);
    }

    public event Action OnLandmarkUpgrade;// ��������¼�
    public void UpgradeLandmark(string buildingName)
    {
        LandmarkData LandmarkData = LoadLandmarkData(buildingName);
        LandmarkData.Upgrade();
        OnLandmarkUpgrade?.Invoke();
        SaveBuildingData(LandmarkData);
    }

    public event Action OnAltarUpgrade;// ��̳�����¼�
    public void UpgradeAltar(string buildingName)
    {
        AltarData AltarData = LoadAltarData(buildingName);
        AltarData.Upgrade();
        OnAltarUpgrade?.Invoke();
        SaveBuildingData(AltarData);
    }

    #endregion

    // ���潨��״̬����
    private void SaveBuildingData(BuildingData buildingData)
    {
        string jsonString = JsonUtility.ToJson(buildingData);
        PlayerPrefs.SetString(buildingData.buildingName, jsonString);
        PlayerPrefs.Save();
        OnBuildingUpdated?.Invoke(buildingData);

        SaveBuildingDataToFile(buildingData);
    }


    // ���潨��״̬���ݵ�JSON�ļ�
    private void SaveBuildingDataToFile(BuildingData buildingData)
    {
        string jsonString = JsonUtility.ToJson(buildingData);
        string filePath = GetBuildingDataFilePath(buildingData.buildingName);

        Debug.Log($"Saving building data to {filePath}");
        // д�� JSON �ļ�
        File.WriteAllText(filePath, jsonString);

        OnBuildingUpdated?.Invoke(buildingData);
    }

    #region ���ݶ�ȡ
    // ��JSON�ļ��м��ؽ���״̬����
    private BuildingData LoadBuildingDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // ��ȡ JSON �ļ�
            string jsonString = File.ReadAllText(filePath);
            BuildingData buildingData =  JsonUtility.FromJson<BuildingData>(jsonString);
            return buildingData;
        }
        else
        {
            // ����ļ������ڣ�����һ���µĽ������ݶ���
            return CreateNewBuildingData(buildingName);
        }
    }

    private DiscipleResidenceData LoadDiscipleResidenceDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // ��ȡ JSON �ļ�
            string jsonString = File.ReadAllText(filePath);
            DiscipleResidenceData DiscipleResidenceData = JsonUtility.FromJson<DiscipleResidenceData>(jsonString);
            return DiscipleResidenceData;
        }
        else
        {
            // ����ļ������ڣ�����һ���µĽ������ݶ���
            return CreateNewDiscipleResidenceData(buildingName);
        }
    }
    private LandmarkData LoadLandmarkDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // ��ȡ JSON �ļ�
            string jsonString = File.ReadAllText(filePath);
            LandmarkData LandmarkData = JsonUtility.FromJson<LandmarkData>(jsonString);
            return LandmarkData;
        }
        else
        {
            // ����ļ������ڣ�����һ���µĽ������ݶ���
            return CreateNewLandmarkData(buildingName);
        }
    }
    private StatueData LoadStatueDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // ��ȡ JSON �ļ�
            string jsonString = File.ReadAllText(filePath);
            StatueData StatueData = JsonUtility.FromJson<StatueData>(jsonString);
            return StatueData;
        }
        else
        {
            // ����ļ������ڣ�����һ���µĽ������ݶ���
            return CreateNewStatueData(buildingName);
        }
    }
    private AltarData LoadAltarDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // ��ȡ JSON �ļ�
            string jsonString = File.ReadAllText(filePath);
            AltarData AltarData = JsonUtility.FromJson<AltarData>(jsonString);
            return AltarData;
        }
        else
        {
            // ����ļ������ڣ�����һ���µĽ������ݶ���
            return CreateNewAltarData(buildingName);
        }
    }

    private BuildingData CreateNewBuildingData(string buildingName)
    {
                return new BuildingData();
    }
    private DiscipleResidenceData CreateNewDiscipleResidenceData(string buildingName)
    {
                return new DiscipleResidenceData();
    }
    private LandmarkData CreateNewLandmarkData(string buildingName)
    {
                return new LandmarkData();
    }
    private StatueData CreateNewStatueData(string buildingName)
    {
                return new StatueData();
    }
    private AltarData CreateNewAltarData(string buildingName)
    {
                return new AltarData();
    }

    #endregion

    // ��ȡ���������ļ�·��
    private string GetBuildingDataFilePath(string buildingName)
    {
        // ����ʹ�� Application.persistentDataPath ��ȡ�־û�����·��
        // ��Ҳ����ʹ������·���������������
        return Path.Combine(Application.persistentDataPath, $"{buildingName}.json");
    }
}

