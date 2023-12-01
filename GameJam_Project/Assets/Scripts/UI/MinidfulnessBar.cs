using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MinidfulnessBar : MonoBehaviour
{
    public GameData gameData;
    public BattleController BattleController;

    public Image foreground;  // ������ǰ��

    public float maxEnergy = 5;  // �������ֵ
    public double currentEnergy; // ��ǰ����ֵ
    public double energyIncreaseRate;// ���������ٶ�

    private void Update()
    {
        currentEnergy = BattleController.GetComponent<BattleController>().GetMata();
        energyIncreaseRate = BattleController.GetComponent<BattleController>().GetPerMata();

        // ÿ֡��������ֵ
        IncreaseEnergy((float)(energyIncreaseRate * Time.deltaTime));

        // ��������������ʾ
        UpdateEnergyBar();
    }

    void IncreaseEnergy(float amount)
    {
        currentEnergy += amount;

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
