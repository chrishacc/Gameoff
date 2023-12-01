using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    //public GameData gameData;
    //public BattleController BattleController;
    public GameObject Boss;

    public Image foreground;  // Ѫ��ǰ��

    public float maxEnergy = 60;  // ���Ѫֵ
    public double currentEnergy; // ��ǰѪ��
    public double energyIncreaseRate;// ���������ٶ�

    private void Update()
    {
        currentEnergy = Boss.GetComponent<Frost>().GetHP();
        //energyIncreaseRate = BattleController.GetComponent<BattleController>().GetPerMata();

        // ÿ֡��������ֵ
        //IncreaseEnergy((float)(energyIncreaseRate * Time.deltaTime));

        // ��������������ʾ
        UpdateEnergyBar();
    }

    void IncreaseEnergy(float amount)
    {
        //currentEnergy += amount;

        // ��������ֵ�����ֵ��Χ��
        currentEnergy = Mathf.Clamp((float)currentEnergy, 0f, maxEnergy);
    }

    void UpdateEnergyBar()
    {

        // ����ǰ����������
        float fillAmount = (float)(currentEnergy / maxEnergy);

        // ����ǰ����������
        foreground.fillAmount = fillAmount;
    }
}
