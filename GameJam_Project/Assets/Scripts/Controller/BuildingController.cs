using System;
using System.IO;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private BuildingModel buildingModel;

    // 建筑数据更新事件
    public event Action<BuildingData> OnBuildingUpdated;

    private void Awake()
    {
        buildingModel = new BuildingModel();
    }

    #region 获取建筑数据
    // 获取当前建筑数据
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

    #region 建筑升级

    public event Action OnBuildingUpgrade;
    // 提升建筑等级
    public void UpgradeBuilding(string buildingName)
    {
        BuildingData buildingData = buildingModel.GetBuildingData(buildingName);
        buildingData.Upgrade();
        SaveBuildingData(buildingData);
    }

    public event Action OnDiscipleResidenceUpgrade;// 信徒住所升级事件
    public void UpgradeDiscipleResidence(string buildingName)
    {
        DiscipleResidenceData DiscipleResidenceData = LoadDiscipleResidenceData(buildingName);
        DiscipleResidenceData.Upgrade();
        OnDiscipleResidenceUpgrade?.Invoke();
        SaveBuildingData(DiscipleResidenceData);
    }

    public event Action OnLandmarkUpgrade;// 纪念碑升级事件
    public void UpgradeLandmark(string buildingName)
    {
        LandmarkData LandmarkData = LoadLandmarkData(buildingName);
        LandmarkData.Upgrade();
        OnLandmarkUpgrade?.Invoke();
        SaveBuildingData(LandmarkData);
    }

    public event Action OnAltarUpgrade;// 祭坛升级事件
    public void UpgradeAltar(string buildingName)
    {
        AltarData AltarData = LoadAltarData(buildingName);
        AltarData.Upgrade();
        OnAltarUpgrade?.Invoke();
        SaveBuildingData(AltarData);
    }

    #endregion

    // 保存建筑状态数据
    private void SaveBuildingData(BuildingData buildingData)
    {
        string jsonString = JsonUtility.ToJson(buildingData);
        PlayerPrefs.SetString(buildingData.buildingName, jsonString);
        PlayerPrefs.Save();
        OnBuildingUpdated?.Invoke(buildingData);

        SaveBuildingDataToFile(buildingData);
    }


    // 保存建筑状态数据到JSON文件
    private void SaveBuildingDataToFile(BuildingData buildingData)
    {
        string jsonString = JsonUtility.ToJson(buildingData);
        string filePath = GetBuildingDataFilePath(buildingData.buildingName);

        Debug.Log($"Saving building data to {filePath}");
        // 写入 JSON 文件
        File.WriteAllText(filePath, jsonString);

        OnBuildingUpdated?.Invoke(buildingData);
    }

    #region 数据读取
    // 从JSON文件中加载建筑状态数据
    private BuildingData LoadBuildingDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // 读取 JSON 文件
            string jsonString = File.ReadAllText(filePath);
            BuildingData buildingData =  JsonUtility.FromJson<BuildingData>(jsonString);
            return buildingData;
        }
        else
        {
            // 如果文件不存在，返回一个新的建筑数据对象
            return CreateNewBuildingData(buildingName);
        }
    }

    private DiscipleResidenceData LoadDiscipleResidenceDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // 读取 JSON 文件
            string jsonString = File.ReadAllText(filePath);
            DiscipleResidenceData DiscipleResidenceData = JsonUtility.FromJson<DiscipleResidenceData>(jsonString);
            return DiscipleResidenceData;
        }
        else
        {
            // 如果文件不存在，返回一个新的建筑数据对象
            return CreateNewDiscipleResidenceData(buildingName);
        }
    }
    private LandmarkData LoadLandmarkDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // 读取 JSON 文件
            string jsonString = File.ReadAllText(filePath);
            LandmarkData LandmarkData = JsonUtility.FromJson<LandmarkData>(jsonString);
            return LandmarkData;
        }
        else
        {
            // 如果文件不存在，返回一个新的建筑数据对象
            return CreateNewLandmarkData(buildingName);
        }
    }
    private StatueData LoadStatueDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // 读取 JSON 文件
            string jsonString = File.ReadAllText(filePath);
            StatueData StatueData = JsonUtility.FromJson<StatueData>(jsonString);
            return StatueData;
        }
        else
        {
            // 如果文件不存在，返回一个新的建筑数据对象
            return CreateNewStatueData(buildingName);
        }
    }
    private AltarData LoadAltarDataFromFile(string buildingName)
    {
        string filePath = GetBuildingDataFilePath(buildingName);

        if (File.Exists(filePath))
        {
            // 读取 JSON 文件
            string jsonString = File.ReadAllText(filePath);
            AltarData AltarData = JsonUtility.FromJson<AltarData>(jsonString);
            return AltarData;
        }
        else
        {
            // 如果文件不存在，返回一个新的建筑数据对象
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

    // 获取建筑数据文件路径
    private string GetBuildingDataFilePath(string buildingName)
    {
        // 这里使用 Application.persistentDataPath 获取持久化数据路径
        // 你也可以使用其他路径，根据你的需求
        return Path.Combine(Application.persistentDataPath, $"{buildingName}.json");
    }
}

