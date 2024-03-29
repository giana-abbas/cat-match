using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject gameMenu;
    public GameObject winMenu;
    public Card card;
    public Card card1;
    public Card card2;
    public int numFlippedCards = 0;
    private bool matching = false;
    private bool matchWait = false;

    public Sprite[] cardTypeList;
    private static int pairAmount = 3;
    public Sprite[] cardsList = new Sprite[pairAmount * 2];

    private int cardAssignIndex = 0;



    void Awake()
    {
        shuffle(cardTypeList);
        instantiateCardList();
        //debugPrintArray(cardsList);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && winMenu.activeInHierarchy == false)
        {
            //set game menu to active
            gameMenu.gameObject.SetActive(true);
        }

        // check if cards clicked
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && (Input.GetMouseButtonUp(0)))
        {
            card = hit.transform.gameObject.GetComponent<Card>();

            if (card.active)
            {
                if (!matching)
                {
                    card1 = card;
                    card.FlipCard();
                    matching = true;
                }
                else if (matching && !matchWait)
                {
                    if (card == card1)
                    {
                        card.FlipCard();
                        matching = false;
                    }
                    else
                    {
                        matchWait = true;
                        card2 = card;
                        card.FlipCard();

                        StartCoroutine(Match(card1, card2));
                    }
                }
            }
        }

    }

    // waits for 1 second
    private IEnumerator Match(Card card1, Card card2)
    {
        bool match = compareCards(card1, card2);
        if (match)
        {
            card1.active = false;
            card2.active = false;
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            card1.FlipCard();
            card2.FlipCard();
        }
        matching = false;
        matchWait = false;

        if (numFlippedCards == pairAmount * 2)
        {
            Debug.Log("All cards flipped");
            winMenu.gameObject.SetActive(true);
        }
    }

    // method shuffles all of the available card types for a level
    private void shuffle(Sprite[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Sprite value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }


    // method creates shuffled array of card types that will be used in the level
    private void instantiateCardList()
    {
        int j = 0;
        for (int i = 0; i < pairAmount * 2; i = i + 2)
        {
            cardsList[i] = cardTypeList[j];
            cardsList[i + 1] = cardTypeList[j];
            j++;
        }
        shuffle(cardsList);
    }


    // method returns a card type from cardsList and increments the cardAssignIndex
    public Sprite assignCard()
    {
        Sprite nextSprite = cardsList[cardAssignIndex];
        cardAssignIndex++;
        return nextSprite;
    }

    // compares two card faces
    private bool compareCards(Card card1, Card card2)
    {
        bool match;

        if (card1.cardFace == card2.cardFace)
        {
            match = true;
        }
        else
        {
            match = false;
        }

        return match;
    }

    // prints an array
    private void debugPrintArray(Sprite[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log(array[i]);
        }
    }
}
