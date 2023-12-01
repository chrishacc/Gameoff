using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleUIView : MonoBehaviour
{
    public GameData gameData;

    [SerializeField] private TextMeshProUGUI numPeopleText;

    // Start is called before the first frame update
    void Start()
    {
        OnBeginUpdateUI();
    }

    private void OnBeginUpdateUI()
    {
        numPeopleText.text = $"People: {gameData.numPeople}/{gameData.maxPeople}";
    }

    // Update is called once per frame
    void Update()
    {
        OnBeginUpdateUI();
    }
}
