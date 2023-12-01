using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm: MonoBehaviour
{
    public float HP;
    private float nowtime;
    private float randseed;
    private double x;
    private int num;
    private bool sheild;//=0无护盾，=1有护盾
    private float maxtime;//decides when boss take action
    private BattleController a;
    // Start is called before the first frame update
    void Awake()
    {
        a = GameObject.Find("BattleController").GetComponent<BattleController>();
        HP = 87;
        ResetLogic();
        num = a.batnum;
        sheild = false;
        
    }


    void Update()
    {
        if (nowtime >= maxtime)
        {
            randseed = Random.value;
            
            if (sheild == false)
            {
                x = (a.batnum <= 2 ? (1 - 0.3) * 2 * a.batnum : (1 - 0.3) * 0.75 * a.batnum + 0.25);
                if (randseed <= 0.3)
                {
                    sheild = true;
                }
                else if (randseed > 0.3 && randseed < 1 - x)
                {
                    a.PlayerHP -= 5;
                }
                else if (randseed >= 1 - x)
                {
                    a.Add_Fols(-5);
                }
            }
            else
            {
                x = (a.batnum <= 2 ? 2 * a.batnum : 0.75 * a.batnum + 0.25);
                if (randseed <= x)
                {
                    a.PlayerHP -= 5;
                }
                else if (randseed > x)
                {
                    a.Add_Fols(-5);
                }
            }
            ResetLogic();
        }
        if (HP <= 0) Victory();
    }
    void ResetLogic()
    {
        nowtime = 0;
        maxtime = 3 + Random.value * 2;
        
    }

    public void Injury(int dmg)
    {
        if (sheild == true) sheild = false;
        else HP -= dmg;
    }

    public void Victory()
    {

    }
}
