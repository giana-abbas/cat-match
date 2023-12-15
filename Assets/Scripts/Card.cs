using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public LevelManager levelManager;
    public Sprite cardFace;
    public Sprite cardBack;

    private bool faceUp;
    public bool active;
    float cardScale = 2f;

    // Start is called before the first frame update
    void Start()
    {
        faceUp = false;
        active = true;
        cardFace = levelManager.assignCard();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // flip cards
    public void FlipCard()
    {
        if (!faceUp)
        {
            spriteRenderer.sprite = cardFace;
            spriteRenderer.size = new Vector3(cardScale, cardScale, 1);
            levelManager.numFlippedCards++;
            faceUp = true;
        }
        else if (faceUp)
        {
            spriteRenderer.sprite = cardBack;
            spriteRenderer.size = new Vector3(cardScale, cardScale, 1);
            levelManager.numFlippedCards--;
            faceUp = false;
        }
    }
}
