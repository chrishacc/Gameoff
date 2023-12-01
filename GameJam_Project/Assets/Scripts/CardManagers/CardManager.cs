using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public int size;

    private readonly Stack<GameObject> instances = new Stack<GameObject>();

    private void Awake()
    {
        Assert.IsNotNull(cardPrefab);
    }

    public void Initialize()
    {
        for (int i = 0; i < size; i++)
        {
            var obj = CreateInstance();
            obj.SetActive(false);
            instances.Push(obj);
        }
    }

    private GameObject CreateInstance()
    {
        var cardObject = Instantiate(cardPrefab,transform,true);
        
        return cardObject;
    }

    public GameObject GetObject()
    {
        var obj = instances.Count > 0 ? instances.Pop() : CreateInstance();
        obj.SetActive(true);
        return obj;
    }
}
