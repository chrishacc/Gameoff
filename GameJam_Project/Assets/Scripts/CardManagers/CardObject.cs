using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Text;

public class CardObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro costText;
    [SerializeField] private TextMeshPro nameText;
    [SerializeField] private TextMeshPro typeText;
    [SerializeField] private TextMeshPro descriptionText;

    //[SerializeField] private SpriteRenderer picture;

    public CardTemplate template;
    public RuntimeCard runtimeCard;

    private void Start()
    {
        var testCard = new RuntimeCard
        {
            Template = template
        };

        SetCard(testCard);
    
    }

    public void SetCard(RuntimeCard card)
    {
        runtimeCard = card;
        template = card.Template;

        //picture.sprite = template.picture;

        //costText.text = template.cost.ToString();
        //nameText.text = template.name;
        //typeText.text = template.type.typeName;
        //var builder = new StringBuilder();
        //descriptionText.text = builder.ToString();
    }
}
