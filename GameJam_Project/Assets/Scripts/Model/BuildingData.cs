using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
[Serializable]
public class BuildingData
{
    public string buildingName;
    public int buildingLevel;
    public GameManager gm ;
    // Other generic building data

    public virtual void Upgrade()
    {
        //Logic Lacked
    }
}

[Serializable]
public class DiscipleResidenceData : BuildingData
{
    public int discipleResidenceUpgradeCost = 20;
    
    public override void Upgrade()
    {
        gm = GameObject.Find("GameController").GetComponent<GameController>().gameManager;
        if (gm.faith >= discipleResidenceUpgradeCost&&buildingLevel<=4)
        { 
            this.buildingLevel++;
            gm.faith -= discipleResidenceUpgradeCost;
            gm.house += 3;
        }

    }
    // Additional properties specific to DiscipleResidence
}

[Serializable]
public class LandmarkData : BuildingData
{
    public int landmarkUpgradeCost=20;
    // Additional properties specific to Landmark
    public override void Upgrade()
    {
        gm = GameObject.Find("GameController").GetComponent<GameController>().gameManager;
        if (gm.faith >= landmarkUpgradeCost && buildingLevel <= 4)
        {
            this.buildingLevel++;
            gm.faith -= landmarkUpgradeCost;
            gm.per_power+=1;
        }

    }
}

[Serializable]
public class StatueData : BuildingData
{
    // Additional properties specific to Statue

}

[Serializable]
public class AltarData : BuildingData
{
    public int altarUpgradeCost=20;
    // Additional properties specific to Altar
    public override void Upgrade()
    {
        gm = GameObject.Find("GameController").GetComponent<GameController>().gameManager;
        if (gm.faith >= altarUpgradeCost && buildingLevel <= 4)
        {
            this.buildingLevel++;
            
        }

    }
}


public class BuildingModel
{
    private Dictionary<string, BuildingData> buildingDataDictionary;

    public BuildingModel()
    {
        buildingDataDictionary = new Dictionary<string, BuildingData>();

        // 初始化建筑数据
        buildingDataDictionary["DiscipleResidence"] = new DiscipleResidenceData { buildingName = "DiscipleResidence", buildingLevel = 1, discipleResidenceUpgradeCost = 20};
        buildingDataDictionary["Landmark"] = new LandmarkData { buildingName = "Landmark", buildingLevel = 1 , landmarkUpgradeCost = 20};
        buildingDataDictionary["Statue"] = new StatueData { buildingName = "Statue", buildingLevel = 1 };
        buildingDataDictionary["Altar"] = new AltarData { buildingName = "Altar", buildingLevel = 1 , altarUpgradeCost = 20};
    }

    public BuildingData GetBuildingData(string buildingName)
    {
        if (buildingDataDictionary.ContainsKey(buildingName))
        {
            return buildingDataDictionary[buildingName];
        }
        else
        {
            // Handle error or return default data
            return new BuildingData();
        }
    }
}

