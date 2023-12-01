using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CardDisplayManager : MonoBehaviour
{
    private const int PositionNumber = 20;
    private const int RotationNumber = 20;
    private const int SortingOrderNumber = 20;

    private CardManager _cardManager;

    private List<Vector3> positions;
    private List<Quaternion> rotations;
    private List<int> sortingOrder;

    private readonly List<GameObject> handCards = new(PositionNumber);

    private const float Radius = 16.0f;

    private readonly Vector3 center = new (0.0f, -18.5f, 0.0f);
    private readonly Vector3 originalCardScale = new (3.0f, 4.0f, 1.0f);

    private bool isCardMoving;

    public void Initialize(CardManager cardManager)
    {
        _cardManager = cardManager;
    }

    private void Awake()
    {
        positions = new (PositionNumber);
        rotations = new (RotationNumber);
        sortingOrder = new (SortingOrderNumber);
    }

    public void CreateHandCards(List<RuntimeCard> cardsInHand)
    {
        var drawnCards = new List<GameObject>(cardsInHand.Count);

        foreach(var card in cardsInHand)
        {
            var cardGameObject = CreateCardGameObject(card);
            handCards.Add(cardGameObject);
            drawnCards.Add(cardGameObject);
        }
        Debug.Log("Number of cards in hand: " + handCards.Count);
        PutDeckCardsToHand(drawnCards);

        
    }

    private GameObject CreateCardGameObject(RuntimeCard card)
    {
        var gameObj = _cardManager.GetObject();
        var cardObject = gameObj.GetComponent<CardObject>();
        cardObject.SetCard(card);

        gameObj.transform.position = Vector3.zero;
        gameObj.transform.localScale = Vector3.zero;

        return gameObj;
    }

    private void PutDeckCardsToHand(List<GameObject> drawnCards)
    {
        isCardMoving = true;

        OrganizeHandCards();

        var interval = 0.0f;

        for(var i = 0; i < handCards.Count; i++)
        {
            var j = i;

            const float time = 0.5f;

            var card = handCards[i];

            if(drawnCards.Contains(card))
            {
                var cardObject = card.GetComponent<CardObject>();

                var seq = DOTween.Sequence();
                seq.AppendInterval(interval);
                seq.AppendCallback(() =>
                {
                    var move = card.transform.DOMove(positions[j], time);

                    card.transform.DORotateQuaternion(rotations[j], time);
                    card.transform.DOScale(originalCardScale, time);

                    if(j == handCards.Count - 1)
                    {
                        move.OnComplete(() =>
                        {
                            isCardMoving = false;
                        });
                    }
                });
            }

            card.GetComponent<SortingGroup>().sortingOrder = sortingOrder[i];

            interval += 0.2f;
        }
    }

    private void OrganizeHandCards()
    {
        positions.Clear();
        rotations.Clear();
        sortingOrder.Clear();

        const float angle = 5.0f;
        var cardAngle =  (handCards.Count - 1) * angle / 2;
        var z = 0.0f;

        for(var i = 0; i < handCards.Count; ++i)
        {
            //Rotation
            var rotation = Quaternion.Euler(0, 0, cardAngle - i * angle);
            rotations.Add(rotation);

            //Move
            z-=0.1f;
            var position = CalculateCardPosition(cardAngle - i * angle);
            position.z = z;
            positions.Add(position);

            sortingOrder.Add(i);
        }


    }

    private Vector3 CalculateCardPosition(float angle)
    {
        return new Vector3(
            center.x - Radius * Mathf.Sin(Mathf.Deg2Rad * angle),
            center.y + Radius * Mathf.Cos(Mathf.Deg2Rad * angle),
            0.0f);
    }
}
