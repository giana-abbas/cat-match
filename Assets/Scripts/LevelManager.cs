using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{    
    public int numFlippedCards = 0;

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
        if (numFlippedCards == pairAmount * 2) {
            //Debug.Log("All cards flipped");
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }

    // method shuffles all of the available card types for a level
    private void shuffle(Sprite[] array)
    {
        int n = array.Length;  
        while (n > 1) {  
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
        for (int i = 0; i < pairAmount*2; i = i + 2) {
            cardsList[i] = cardTypeList[j];
            cardsList[i+1] = cardTypeList[j];
            j++;
        }
        shuffle(cardsList);
    }


    // method returns a card type from cardsList and increments the cardAssignIndex
    public Sprite assignCard() {
        Sprite nextSprite = cardsList[cardAssignIndex];
        cardAssignIndex++;
        return nextSprite;
    }

    // prints an array
    private void debugPrintArray(Sprite[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            Debug.Log(array[i]);
        }
    }
}
