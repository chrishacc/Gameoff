using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCard : MonoBehaviour
{
    //public string[] namecard;
    
    public Dictionary<int, GameObject> CardDic;
    public GameObject nowitem1;
    public GameObject nowitem2;
    public GameObject nowitem3;
    public GameObject nowitem4;
    public GameObject nowitem5;
    public GameObject nowitem6;
    public GameObject nowitem7;
    public GameObject nowitem8;
    public GameObject nowitem9;
    public GameObject nowitem10;
    public GameObject nowitem11;
    public GameObject nowitem12;
    public GameObject nowitem13; 
    public GameObject nowitem14;
    public GameObject nowitem15;
    public GameObject nowitem16; 
    public GameObject nowitem17;
    public GameObject nowitem18;
    public GameObject nowitem19;
    public GameObject nowitem20;
    //public GameObject nowitem14;
    //public GameObject nowitem1;
    // Start is called before the first frame update
    void Awake()
    {
        CardDic = new Dictionary<int, GameObject>();
        /*namecard= new string[] {
           "Template", 
           "MindArrow", 
           "BodilyExplosion", 
           "Encouragement", 
           "Contemplation", 
           "Create", 
           "SendTroops", 
           "ComeHere", 
           "BloodExplosion", 
           "blessing", 
           "MindMissle", 
           "SpiritImprint", 
           "BloodSacrifice", 
           "Eat", 
           "Inspiration", 
           "GetTeached", 
           "FaceDeath", 
           "StrenthenFaith", 
           "Perish", 
           "Clone", 
           "Incorporate" 
       };*/
        
        //Instantiate(a);
    }

    public GameObject Getcard(int id)
    {
        return CardDic[id];
    }

    public void CreatCard(int id)
    {
        if (id == 1) CardDic[id] = Instantiate(nowitem1);
        if (id == 2) CardDic[id] = Instantiate(nowitem2);
        if (id == 3) CardDic[id] = Instantiate(nowitem3);
        if (id == 4) CardDic[id] = Instantiate(nowitem4);
        if (id == 5) CardDic[id] = Instantiate(nowitem5);
        if (id == 6) CardDic[id] = Instantiate(nowitem6);
        if (id == 7) CardDic[id] = Instantiate(nowitem7);
        if (id == 8) CardDic[id] = Instantiate(nowitem8);
        if (id == 9) CardDic[id] = Instantiate(nowitem9);
        if (id == 10) CardDic[id] = Instantiate(nowitem10);
        if (id == 11) CardDic[id] = Instantiate(nowitem11);
        if (id == 12) CardDic[id] = Instantiate(nowitem12);
        if (id == 13) CardDic[id] = Instantiate(nowitem13);
        if (id == 14) CardDic[id] = Instantiate(nowitem14);
        if (id == 15) CardDic[id] = Instantiate(nowitem15);
        if (id == 16) CardDic[id] = Instantiate(nowitem16);
        if (id == 17) CardDic[id] = Instantiate(nowitem17);
        if (id == 18) CardDic[id] = Instantiate(nowitem18);
        if (id == 19) CardDic[id] = Instantiate(nowitem19);
        if (id == 20) CardDic[id] = Instantiate(nowitem20);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
