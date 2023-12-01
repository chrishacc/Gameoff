using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightButton : MonoBehaviour
{
    private int thisturn;
    private CardSAPManager a;
    public Button thisbutton;
    private int avanum;
    private List<int> SelectedDeck;//SelectedDeck需要序列化，在战斗场景中读取它。

    public void Start()
    {
        a = GameObject.Find("CardSAPManager").GetComponent<CardSAPManager>();

        avanum = 0;
        SelectedDeck = new List<int>();
    }

    public void OnFightClick()
    {
        if (a.selectedlist.Count != 6)
        {
            return;
        }
        for(int i = 0; i < a.selectedlist.Count; i++)
        {
            if (a.isavaible[a.selectedlist[i]] == 0)
            {
                return;
            }
        }
        for (int i = 0; i < a.selectedlist.Count; i++)
        {
            SelectedDeck.Add(a.selectedlist[i]);
        }

        a.SaveGame();

        if (a.turn == 20)
        {
            
            SceneManager.LoadScene("BattleScene01");
        }
        else if (a.turn == 38)
        {
            
            SceneManager.LoadScene("BattleScene02");
        }
        else if (a.turn == 50)
        {
            
            SceneManager.LoadScene("BattleScene03");
        }
        
        else
        {
            //Card not enough;
        }
        
        
        
    }
    // Update is called once per frame

    void Update()
    {
        if (a.selectedlist.Count != 6) thisbutton.interactable = false;
        if (a.turn != 20 || a.turn != 38 || a.turn != 50) thisbutton.interactable = false;
    }
}
