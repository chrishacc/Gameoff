using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Sun : MonoBehaviour
{
    public float HP;
    private float nowtime;
    private float randseed;
    private float p1,p2;
    private int num;
    private int time1;

    private float maxtime;//decides when boss take action
    private BattleController a;
    private float rstime;
    // Start is called before the first frame update
    void Awake()
    {
        a = GameObject.Find("BattleController").GetComponent<BattleController>();
        HP = 60;
        ResetLogic();
        num = a.batnum;
        time1 = 0;
        p1 = (a.batnum <= 2) ? (2 / 3f) * 2 * a.batnum : (float)0.75 * a.batnum + (float)0.25;
        p2 = (a.batnum <= 2) ? (1 / 3f) * 2 * a.batnum : (float)0.75 * a.batnum + (float)0.25;
        
        rstime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        nowtime += Time.deltaTime;
        if (rstime > 0)
        {
            rstime -= Time.deltaTime;
            if (rstime < 0) rstime = 0;
        }
        if (nowtime >= maxtime)
        {
            p1 = (a.batnum <= 2) ? (2 / 3f) * 2 * a.batnum : (float)0.75 * a.batnum + (float)0.25;
            p2 = (a.batnum <= 2) ? (1 / 3f) * 2 * a.batnum : (float)0.75 * a.batnum + (float)0.25;
            randseed = Random.value;
            if (randseed < 1 - p1 - p2)
            {
                a.PlayerHP -= (4 + (time1++) );
            }
            else if (randseed >= 1 - p2)
            {
                rstime = 3;
            }
            else
            {
                if (a.batnum >= 7) a.Add_Fols(-7);
                else
                {
                    a.PlayerHP -= (7 - a.batnum);
                    a.Add_Fols(0);
                }
            }
            ResetLogic();
        }
        
        if (HP <= 0) Victory();
    }
    void ResetLogic()
    {
        nowtime = 0;
        maxtime = 4 + Random.value * 2;

    }

    public void Injury(int dmg)
    {
        if (rstime > 0)
        {
            HP = (200 > HP + dmg) ? HP + dmg : 200;
        }
        else
        {
            HP -= dmg ;
        }
    }
    public void Victory()
    {

    }
}