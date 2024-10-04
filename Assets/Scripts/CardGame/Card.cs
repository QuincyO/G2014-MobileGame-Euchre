using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Card : MonoBehaviour
{
    private const int CardFaces = 2;
    
    private string _cardName;
    
    [SerializeField]
    public CardInfo cardInfo;

    private MeshRenderer[] _cardFaces = new MeshRenderer[CardFaces];
    

    public string CardName()
    {
        if (cardInfo == null) cardInfo = AssetDatabase.LoadAssetAtPath<CardInfo>("Assets/ScriptableObjects/EmptyCard.asset");
        else _cardName = cardInfo.cardValue + " of " + cardInfo.cardSuit;
        return _cardName;
    }
    void OnValidate()
    {
       // CardName();
       // _cardFaces[0] = transform.Find("Front Face").GetComponent<MeshRenderer>();
       // _cardFaces[1] = transform.Find("Back Face").GetComponent<MeshRenderer>();
       // _cardFaces[0].material.mainTexture = cardInfo.FrontFace;
       // _cardFaces[1].material.mainTexture = cardInfo.BackFace;

    }

    private void Start()
    {
        CardName();
        _cardFaces[0] = transform.Find("Front Face").GetComponent<MeshRenderer>();
        _cardFaces[1] = transform.Find("Back Face").GetComponent<MeshRenderer>();
        _cardFaces[0].material.mainTexture = cardInfo.FrontFace;
        _cardFaces[1].material.mainTexture = cardInfo.BackFace;
    }
}
