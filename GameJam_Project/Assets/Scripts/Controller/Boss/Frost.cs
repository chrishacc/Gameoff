using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost : MonoBehaviour
{
    public float HP;
    private float nowtime;
    private float randseed;
    private float x;
    private int num;
    
    private float maxtime;//decides when boss take action
    private BattleController a;
    // Start is called before the first frame update
    void Awake()
    {
        a = GameObject.Find("BattleController").GetComponent<BattleController>();
        HP = 60;
        ResetLogic();
        num = a.batnum;
        
        x = (float)(0.75) * num+(float)0.25;
    }

    // Update is called once per frame
    void Update()
    {
        
        nowtime += Time.deltaTime;
        if (nowtime >= maxtime)
        {
            randseed = Random.value;
            if (randseed < x)
            {

                a.PlayerHP -= 5;
            }
            else
            {
                a.Add_Fols(0);
            }
            ResetLogic();
        }
        x = (float)(0.75) * num + (float)0.25;
        if (HP <= 0) Victory();
    }
    void ResetLogic()
    {
        nowtime = 0;
        maxtime = 4 + Random.value * 2;
        
    }

    public void Injury(int dmg)
    {
        HP -= dmg;
    }

    public void Victory()
    {

    }

    public float GetHP()
    {
        return HP;
    }
}
