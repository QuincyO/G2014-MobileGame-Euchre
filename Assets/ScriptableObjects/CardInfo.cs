using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/New Card")]
public class CardInfo : ScriptableObject
{
    public CardSuit cardSuit;
    public Texture FrontFace;
    public Texture BackFace;
    public CardValue cardValue;
    public CardColor Color;

    public enum CardColor
    {
        None,
        Black,
        Red
    }

    private void OnEnable()
    {
        if (BackFace == null) BackFace = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Euchre/Card Back 2.png");

        if (cardSuit == CardSuit.Clubs || cardSuit == CardSuit.Spades)
        {
            Color = CardColor.Black;
        }
        else Color = CardColor.Red;
    }
}
