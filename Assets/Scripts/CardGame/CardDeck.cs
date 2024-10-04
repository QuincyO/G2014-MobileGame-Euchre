using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardDeck : MonoBehaviour
{
    
    public GameObject cardPrefab;
    
    
    [SerializeField] private CardInfo[] availableCards;

    private const int MaxCards = 24;

    [SerializeField]
    private GameObject[] cards = new GameObject[MaxCards];

    public void CreateDeck()
    {
        for (int i = 0; i < MaxCards; i++)
        {
            var tempPrefab = Instantiate(cardPrefab, this.transform, true);
            var cardRef = tempPrefab.GetComponent<Card>();
            cardRef.cardInfo = availableCards[i];
            tempPrefab.name = cardRef.CardName();
            cards[i] = tempPrefab;
        }
    }

    [ContextMenu("Refresh")]
    void DoNothing()
    {
        
    }

    //Fisher - Yates Shuffle Method
    [ContextMenu("Shuffle Deck")]
    public bool ShuffleDeck()
    {
        if(cards.Length == 0) return false;

        for (int i = MaxCards - 1; i > 0; i--)
        {
            int j = Random.Range(0, i+1);
            //Tuple Assignment is used instead of creating a variable
            (cards[i], cards[j]) = (cards[j], cards[i]);
            
            #region Traditional Way of Swapping
            //var temp = cards[i];
            //cards[i] = cards[j];
            //cards[j] = temp;
            #endregion
        }
        Debug.Log("Shuffled Deck");
        
        return true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        CreateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
