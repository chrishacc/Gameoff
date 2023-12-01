using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BuildingView : MonoBehaviour
{
    public BuildingController buildingController;
    //public GameObject infoPanel;  // 面板对象

    public GameObject DiscipleResidencePanel;
    public GameObject LandmarkPanel;
    public GameObject StatuePanel;
    public GameObject AltarPanel;

    //public Button upgradeButton;
    //public TextMeshProUGUI buildingNameText;
    //public TextMeshProUGUI buildingLevelText;
    //public TextMeshProUGUI upgradeCostText;

    public Button DiscipleResidenceUpgradeButton;
    public Button LandmarkUpgradeButton;
    //public Button StatueUpgradeButton;
    public Button AltarUpgradeButton;

    public TextMeshProUGUI DiscipleResidenceNameText;
    public TextMeshProUGUI LandmarkNameText;
    public TextMeshProUGUI StatueNameText;
    public TextMeshProUGUI AltarNameText;

    public TextMeshProUGUI DiscipleResidenceLevelText;
    public TextMeshProUGUI LandmarkLevelText;
    //public TextMeshProUGUI StatueLevelText;
    public TextMeshProUGUI AltarLevelText;

    public TextMeshProUGUI DiscipleResidenceUpgradeCostText;
    public TextMeshProUGUI LandmarkUpgradeCostText;
    //public TextMeshProUGUI StatueUpgradeCostText;
    public TextMeshProUGUI AltarUpgradeCostText;

    public string buildingName;
    // Other UI elements

    private void Awake()
    {
        
    }

    private void Start()
    {
        // 确保 infoPanel 初始时是禁用的
        //infoPanel.SetActive(false);

        DiscipleResidencePanel.SetActive(false);
        LandmarkPanel.SetActive(false);
        StatuePanel.SetActive(false);
        AltarPanel.SetActive(false);
    }

    //建筑点击展示面板
    public void OnPointerClick()
    {
        AudioManager.Instance.PlaySound("onbutton");
        //infoPanel.SetActive(true);
        
        if (buildingName == "DiscipleResidence")
        {
            DiscipleResidenceData DiscipleResidenceData = buildingController.LoadDiscipleResidenceData(buildingName);
            UpdateInfoPanel(DiscipleResidenceData);

            DiscipleResidencePanel.SetActive(true);

            DiscipleResidenceUpgradeButton.gameObject.SetActive(true);
            LandmarkUpgradeButton.gameObject.SetActive(false);
            //StatueUpgradeButton.gameObject.SetActive(false);
            AltarUpgradeButton.gameObject.SetActive(false);
        }
        else if (buildingName == "Landmark")
        {
            LandmarkData LandmarkData = buildingController.LoadLandmarkData(buildingName);
            UpdateInfoPanel(LandmarkData);

            LandmarkPanel.SetActive(true);

            DiscipleResidenceUpgradeButton.gameObject.SetActive(false);
            LandmarkUpgradeButton.gameObject.SetActive(true);
            //StatueUpgradeButton.gameObject.SetActive(false);
            AltarUpgradeButton.gameObject.SetActive(false);
        }
        else if (buildingName == "Statue")
        {
            StatueData statueData = buildingController.LoadStatueData(buildingName);
            UpdateInfoPanel(statueData);

            StatuePanel.SetActive(true);

            SceneManager.LoadScene("CardSelectionScene");

            DiscipleResidenceUpgradeButton.gameObject.SetActive(false);
            LandmarkUpgradeButton.gameObject.SetActive(false);
            //StatueUpgradeButton.gameObject.SetActive(true);
            AltarUpgradeButton.gameObject.SetActive(false);
        }
        else if (buildingName == "Altar")
        {
            AltarData AltarData = buildingController.LoadAltarData(buildingName);
            UpdateInfoPanel(AltarData);

            AltarPanel.SetActive(true);

            DiscipleResidenceUpgradeButton.gameObject.SetActive(false);
            LandmarkUpgradeButton.gameObject.SetActive(false);
            //StatueUpgradeButton.gameObject.SetActive(false);
            AltarUpgradeButton.gameObject.SetActive(true);
        }

        // 获取点击的建筑数据
        //BuildingData buildingData = buildingController.GetBuildingData(buildingName);

        // 更新信息面板
        //UpdateInfoPanel(buildingData);
    }

    #region 面板更新事件
    // 更新信息面板
    public void UpdateInfoPanel(BuildingData buildingData)
    {
        if (buildingData != null)
        {
            Debug.Log("buildingData not null");
            //buildingNameText.text = $"Building: {buildingData.buildingName}";
            //buildingLevelText.text = $"Level: {buildingData.buildingLevel}";

            DiscipleResidenceNameText.text = $"Disciple Residence";
            LandmarkNameText.text = $"Landmark";
            StatueNameText.text = $"Statue";
            AltarNameText.text = $"Altar";

            DiscipleResidenceLevelText.text = $"Level: {buildingData.buildingLevel}";
            LandmarkLevelText.text = $"Level: {buildingData.buildingLevel}";
            //StatueLevelText.text = $"Level: {buildingData.buildingLevel}";
            AltarLevelText.text = $"Level: {buildingData.buildingLevel}";

            DiscipleResidenceUpgradeCostText.text = $"Upgrade Cost: {20}";
            LandmarkUpgradeCostText.text = $"Upgrade Cost: {20}";
            //StatueUpgradeCostText.text = $"Upgrade Cost: {buildingData.GetUpgradeCost()}";
            AltarUpgradeCostText.text = $"Upgrade Cost: {20}";

            // TODO: 根据建筑类型设置不同的信息，例如升级成本等
            //upgradeCostText.text = $"Upgrade Cost: {buildingData.GetUpgradeCost()}";

            // 设置升级按钮的状态
            //upgradeButton.interactable = buildingData.CanUpgrade();

            // 激活面板
            //infoPanel.SetActive(true);
        }
        else
        {
            // 如果没有建筑数据，禁用面板
            //infoPanel.SetActive(false);
        }
    }

    public void UpdateInfoPanel(DiscipleResidenceData DiscipleResidenceData)
    {
        if (DiscipleResidenceData != null)
        {
            Debug.Log("DiscipleResidenceData not null");

            DiscipleResidenceNameText.text = $"Disciple Residence";
            Debug.Log($"Level: {DiscipleResidenceData.buildingLevel}");
            DiscipleResidenceLevelText.text = $"Level: {DiscipleResidenceData.buildingLevel}";
            
            DiscipleResidenceUpgradeCostText.text = $"Upgrade Cost: {DiscipleResidenceData.discipleResidenceUpgradeCost}";
            
        }
    }

    public void UpdateInfoPanel(LandmarkData LandmarkData)
    {
        if (LandmarkData != null)
        {
            Debug.Log("LandmarkData not null");

            LandmarkNameText.text = $"Landmark";

            LandmarkLevelText.text = $"Level: {LandmarkData.buildingLevel}";
            
            LandmarkUpgradeCostText.text = $"Upgrade Cost: {LandmarkData.landmarkUpgradeCost}";
            
        }
    }

    public void UpdateInfoPanel(StatueData StatueData)
    {
        if (StatueData != null)
        {
            Debug.Log("StatueData not null");

            StatueNameText.text = $"Statue";

            //StatueLevelText.text = $"Level: {StatueData.buildingLevel}";
            
            //StatueUpgradeCostText.text = $"Upgrade Cost: {StatueData.GetUpgradeCost()}";
            
        }
    }

    public void UpdateInfoPanel(AltarData AltarData)
    {
        if (AltarData != null)
        {
            Debug.Log("AltarData not null");

            AltarNameText.text = $"Altar";

            AltarLevelText.text = $"Level: {AltarData.buildingLevel}";
            
            AltarUpgradeCostText.text = $"Upgrade Cost: {AltarData.altarUpgradeCost}";
            
        }
    }

    #endregion


    #region 建筑升级按钮点击方法
    // 升级按钮点击事件
    public void OnUpgradeButtonClick()
    {
        // 获取当前建筑数据
        BuildingData buildingData = buildingController.GetBuildingData(buildingName);

        // 提升建筑等级
        buildingController.UpgradeBuilding(buildingData.buildingName);

        // 更新信息面板
        UpdateInfoPanel(buildingData);
    }

    public void OnDiscipleResidenceUpgradeButtonClick()
    {
        // 获取当前建筑数据
        DiscipleResidenceData DiscipleResidenceData = buildingController.LoadDiscipleResidenceData(buildingName);

        // 提升建筑等级
        buildingController.UpgradeDiscipleResidence(DiscipleResidenceData.buildingName);

        //再次获取更新后的当前建筑数据
        DiscipleResidenceData DiscipleResidenceData2 = buildingController.LoadDiscipleResidenceData(buildingName);

        // 更新建筑信息面板
        UpdateInfoPanel(DiscipleResidenceData2);
    }

    public void OnLandmarkUpgradeButtonClick()
    {
        // 获取当前建筑数据
        LandmarkData LandmarkData = buildingController.LoadLandmarkData(buildingName);

        // 提升建筑等级
        buildingController.UpgradeBuilding(LandmarkData.buildingName);

        // 更新建筑信息面板
        UpdateInfoPanel(LandmarkData);
    }

    public void OnStatueUpgradeButtonClick()
    {
        // 获取当前建筑数据
        StatueData StatueData = buildingController.LoadStatueData(buildingName);

        // 提升建筑等级
        buildingController.UpgradeBuilding(StatueData.buildingName);

        // 更新建筑信息面板
        UpdateInfoPanel(StatueData);
    }

    public void OnAltarUpgradeButtonClick()
    {
        // 获取当前建筑数据
        AltarData AltarData = buildingController.LoadAltarData(buildingName);

        // 提升建筑等级
        buildingController.UpgradeBuilding(AltarData.buildingName);

        // 更新建筑信息面板
        UpdateInfoPanel(AltarData);
    }
    #endregion
}
