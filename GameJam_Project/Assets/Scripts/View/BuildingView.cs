using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BuildingView : MonoBehaviour
{
    public BuildingController buildingController;
    //public GameObject infoPanel;  // ������

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
        // ȷ�� infoPanel ��ʼʱ�ǽ��õ�
        //infoPanel.SetActive(false);

        DiscipleResidencePanel.SetActive(false);
        LandmarkPanel.SetActive(false);
        StatuePanel.SetActive(false);
        AltarPanel.SetActive(false);
    }

    //�������չʾ���
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

        // ��ȡ����Ľ�������
        //BuildingData buildingData = buildingController.GetBuildingData(buildingName);

        // ������Ϣ���
        //UpdateInfoPanel(buildingData);
    }

    #region �������¼�
    // ������Ϣ���
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

            // TODO: ���ݽ����������ò�ͬ����Ϣ�����������ɱ���
            //upgradeCostText.text = $"Upgrade Cost: {buildingData.GetUpgradeCost()}";

            // ����������ť��״̬
            //upgradeButton.interactable = buildingData.CanUpgrade();

            // �������
            //infoPanel.SetActive(true);
        }
        else
        {
            // ���û�н������ݣ��������
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


    #region ����������ť�������
    // ������ť����¼�
    public void OnUpgradeButtonClick()
    {
        // ��ȡ��ǰ��������
        BuildingData buildingData = buildingController.GetBuildingData(buildingName);

        // ���������ȼ�
        buildingController.UpgradeBuilding(buildingData.buildingName);

        // ������Ϣ���
        UpdateInfoPanel(buildingData);
    }

    public void OnDiscipleResidenceUpgradeButtonClick()
    {
        // ��ȡ��ǰ��������
        DiscipleResidenceData DiscipleResidenceData = buildingController.LoadDiscipleResidenceData(buildingName);

        // ���������ȼ�
        buildingController.UpgradeDiscipleResidence(DiscipleResidenceData.buildingName);

        //�ٴλ�ȡ���º�ĵ�ǰ��������
        DiscipleResidenceData DiscipleResidenceData2 = buildingController.LoadDiscipleResidenceData(buildingName);

        // ���½�����Ϣ���
        UpdateInfoPanel(DiscipleResidenceData2);
    }

    public void OnLandmarkUpgradeButtonClick()
    {
        // ��ȡ��ǰ��������
        LandmarkData LandmarkData = buildingController.LoadLandmarkData(buildingName);

        // ���������ȼ�
        buildingController.UpgradeBuilding(LandmarkData.buildingName);

        // ���½�����Ϣ���
        UpdateInfoPanel(LandmarkData);
    }

    public void OnStatueUpgradeButtonClick()
    {
        // ��ȡ��ǰ��������
        StatueData StatueData = buildingController.LoadStatueData(buildingName);

        // ���������ȼ�
        buildingController.UpgradeBuilding(StatueData.buildingName);

        // ���½�����Ϣ���
        UpdateInfoPanel(StatueData);
    }

    public void OnAltarUpgradeButtonClick()
    {
        // ��ȡ��ǰ��������
        AltarData AltarData = buildingController.LoadAltarData(buildingName);

        // ���������ȼ�
        buildingController.UpgradeBuilding(AltarData.buildingName);

        // ���½�����Ϣ���
        UpdateInfoPanel(AltarData);
    }
    #endregion
}
