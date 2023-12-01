using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MinidfulnessBar : MonoBehaviour
{
    public GameData gameData;
    public BattleController BattleController;

    public Image foreground;  // 能量条前景

    public float maxEnergy = 5;  // 最大能量值
    public double currentEnergy; // 当前能量值
    public double energyIncreaseRate;// 能量增长速度

    private void Update()
    {
        currentEnergy = BattleController.GetComponent<BattleController>().GetMata();
        energyIncreaseRate = BattleController.GetComponent<BattleController>().GetPerMata();

        // 每帧增加能量值
        IncreaseEnergy((float)(energyIncreaseRate * Time.deltaTime));

        // 更新能量条的显示
        UpdateEnergyBar();
    }

    void IncreaseEnergy(float amount)
    {
        currentEnergy += amount;

        // 限制能量值在最大值范围内
        currentEnergy = Mathf.Clamp((float)currentEnergy, 0f, maxEnergy);
    }

    void UpdateEnergyBar()
    {
        // 计算前景的填充比例
        float fillAmount = (float)(currentEnergy / maxEnergy);

        // 更新前景的填充比例
        foreground.fillAmount = fillAmount;
    }
}
