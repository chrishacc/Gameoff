using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    //public GameData gameData;
    //public BattleController BattleController;
    public GameObject Boss;

    public Image foreground;  // 血条前景

    public float maxEnergy = 60;  // 最大血值
    public double currentEnergy; // 当前血量
    public double energyIncreaseRate;// 能量增长速度

    private void Update()
    {
        currentEnergy = Boss.GetComponent<Frost>().GetHP();
        //energyIncreaseRate = BattleController.GetComponent<BattleController>().GetPerMata();

        // 每帧增加能量值
        //IncreaseEnergy((float)(energyIncreaseRate * Time.deltaTime));

        // 更新能量条的显示
        UpdateEnergyBar();
    }

    void IncreaseEnergy(float amount)
    {
        //currentEnergy += amount;

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
