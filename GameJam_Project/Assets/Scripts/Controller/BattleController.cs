using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public struct Dmg_Correction {
    public float dms, time;
}

public class BattleController : MonoBehaviour
{
    
    public int PlayerHP;
    public int max_PlayerHP;

    public int memnum;
    public int batnum;//The numbers of members who fight with boss rather than stand behind the player. 
    public float batdmg;//信徒攻击修正
    public float batdmg_time;//信徒攻击修正持续时间
    public float batper_time;//信徒周期修正持续时间
    public float batper;//攻击周期

    public double mata;
    public double per_mata;
    public double magnif;//费用增长倍率
    public double magnif_time;

    public int magic_dmg;
    public float magic_dmg_time;
    public int next_magic_dmg;
    public int teached_dmg;
    public float teached_dmg_time;
    public int spirit;
    public float spirit_time;
    
    //public People mons;
    public int turns;
    public int monsid;
    
    public GameObject Boss;
    private float nowtime,alltime;
    public List<Dmg_Correction>dmgcor;//攻击修正时限列表
    public Dmg_Correction newdmg;

    

    //public GameManager gameManager;



    private void Awake()
    {
        // 创建GameManager实例
        //gameManager = gameObject.AddComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        memnum = GameObject.Find("GameData").GetComponent<GameData>().numPeople;
        turns = GameObject.Find("GameData").GetComponent<GameData>().turn;
        //if (turns == 20)
        //{
        //    Boss = GameObject.Find("Frost");
        //    if (Boss != null) Debug.Log("Finded Boss");
        //    else Debug.Log("Can't Find Boss");
        //}
        //if (turns == 38) Boss = GameObject.Find("Boss2");
        //if (turns == 50) Boss = GameObject.Find("Boss3");

        PlayerHP = 20;
        mata = 0;
        per_mata = 0.5 + memnum * 0.075;
        magnif = 1;

        batdmg = 1;
        batper = 1;
        batdmg_time = 0;
        batper_time = 0;
        nowtime = 0; alltime = 0;

        dmgcor = new List<Dmg_Correction>();
        newdmg = new Dmg_Correction();
    }

    public void OnEnable()
    {
        //memnum = GameObject.Find("GameData").GetComponent<GameData>().numPeople;
        //turns = GameObject.Find("GameData").GetComponent<GameData>().turn;
        ////if (turns == 20)
        ////{
        ////    Boss = GameObject.Find("Frost");
        ////    if (Boss != null) Debug.Log("Finded Boss");
        ////    else Debug.Log("Can't Find Boss");
        ////}
        ////if (turns == 38) Boss = GameObject.Find("Boss2");
        ////if (turns == 50) Boss = GameObject.Find("Boss3");
        
        //mata = 0;
        //per_mata = 0.5 + memnum * 0.075;
        //magnif = 1;
        
        //batdmg = 1;
        //batper = 1;
        //batdmg_time = 0;
        //batper_time = 0;
        //nowtime = 0;alltime = 0;

        //dmgcor = new List<Dmg_Correction>();
        //newdmg = new Dmg_Correction();
        
    }


    public void Add_Fols(int num)//Add or Destroy Followers.num=0 means Destroying all followers. 
    {
        if (num >= 1)
        {
            if (batnum == 0) //GameObject.Find("Followers").SetActive(true);
            batnum += num;
            memnum -= num;
            GameObject.Find("GameData").GetComponent<GameManager>().numPeople -= num;
        }
        else if (num == 0)
        {
            batnum = 0;
            //GameObject.Find("Followers").SetActive(false);
        }
        else if (num < 0)
        {
            if (batnum + num <= 0)
            {
                //GameObject.Find("Followers").SetActive(false);
                batnum = 0;
            }
            else batnum += num;
        }
    }

    // Update is called once per frame
    void Update()
    {
        per_mata = 0.5 + memnum * 0.075;
        alltime += Time.deltaTime;
        nowtime += Time.deltaTime;
        
        DmsFol();

        if (dmgcor.Count > 0) DmgCorTime();

        if (magic_dmg_time != 0) MagicDmg();

        if (spirit_time != 0) SpiritTime();

        if (teached_dmg_time != 0) TeachedDmg();

        if (magnif_time != 0) Magnif_Time();

        Change_Mata();

        if (nowtime >= 1) nowtime = 0;

        if (PlayerHP <= 0) Lose();

        Victory();

        per_mata = 0.5 + memnum * 0.075;

    }
    public void Add_Dmg(float admg)
    {
        newdmg.dms = admg;
        newdmg.time = 3+alltime;
        batdmg += admg;
        dmgcor.Add(newdmg);
    }
    void DmsFol()
    {
        if (batper_time - Time.deltaTime <= 0)
        {
            batper_time = 0;
            batper = 1;
        }
        else
        {
            batper_time -= Time.deltaTime;
        }
        if (nowtime >= batper)
        {
            HPdmg((int)(batnum * (batdmg + spirit)));
        }
        //有修改攻击频率的卡牌，所以单独一个函数。
    }
    void DmgCorTime()
    {
        if (dmgcor.Count>0&&alltime >= dmgcor[0].time)
        {
            batdmg -= dmgcor[0].dms;
            dmgcor.RemoveAt(0);
        }
    }

    public void Direct_Dmg(int basedmg,int times)
    {
        Debug.Log("即将对Boss造成伤害");
        HPdmg((basedmg + magic_dmg + next_magic_dmg + spirit +
            (teached_dmg_time > 0 ? teached_dmg : 0)) * times);
        Debug.Log("对Boss造成伤害");
        if (next_magic_dmg != 0) next_magic_dmg = 0;
    }
    private void MagicDmg()
    {
        if (magic_dmg_time - Time.deltaTime <= 0)
        {
            magic_dmg -= 2;
            magic_dmg_time = 0;
        }
        else
        {
            magic_dmg_time -= Time.deltaTime;
        }
    }
    private void TeachedDmg()
    {
        if (magic_dmg_time - Time.deltaTime <= 0)
        {
            teached_dmg = 0;
            teached_dmg_time = 0;
        }
        else
        {
            teached_dmg_time -= Time.deltaTime;
            teached_dmg = batnum;

        }
    }
    void SpiritTime()
    {
        if (spirit_time - Time.deltaTime <= 0)
        {
            spirit_time= 0;
            batper = 0;
        }
        else
        {
            spirit_time -= Time.deltaTime;
        }
    }

    public void HPdmg(int dmg)
    {
        if (turns == 20)
        {
            Boss.GetComponent<Frost>().Injury(dmg);
        }
        else if (turns == 38)
        {
            Boss.GetComponent<Storm>().Injury(dmg);
        }
        else if (turns == 50)
        {
            Boss.GetComponent<Sun>().Injury(dmg);
        }
    }
    private void Magnif_Time()
    {
        if (magnif_time - Time.deltaTime <= 0)
        {
            magnif = 1;
            magnif_time = 0;
        }
        else
        {
            magnif_time -= Time.deltaTime;
        }
    } 

    private void Change_Mata()
    {
        mata += (Time.deltaTime * per_mata * magnif);
        if (mata > 5) mata = 5;
    }

    public void Change_HP(int _HP,int _maxHP)
    {
        PlayerHP += _HP;
        max_PlayerHP += _maxHP;
        if (PlayerHP >= max_PlayerHP) PlayerHP = max_PlayerHP;
    }


    void Lose()
    {
        //This function should include a Window about Player's Lose.
        SceneManager.LoadScene("Lose");
    }
    void Victory()
    {
        //This function need to skip to the Operation Window.
        if(Boss.GetComponent<Frost>().HP <= 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    public double GetMata()
    {
        return mata;
    }

    public double GetPerMata()
    {
        return per_mata;
    }

    public int GetPlayerHP()
    {
        return PlayerHP;
    }
}
