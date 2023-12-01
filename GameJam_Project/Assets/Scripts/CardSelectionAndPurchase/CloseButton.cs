using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    private CardSAPManager a;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("CardSAPManager").GetComponent<CardSAPManager>();
    }
    public void OnCloseClick()
    {
        a.SaveGame();
        a.SaveCard();
        SceneManager.LoadScene("MainScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
