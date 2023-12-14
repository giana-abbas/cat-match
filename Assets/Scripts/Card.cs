using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{

    Ray ray;
	RaycastHit hit;

    public SpriteRenderer spriteRenderer;
    public LevelManager levelManager;
    public Sprite cardFace;
    public Sprite cardBack;

    private bool faceUp;
    float cardScale = 2f;

    // Start is called before the first frame update
    void Start()
    {
        faceUp = false;
        cardFace = levelManager.assignCard();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit) && (Input.GetMouseButtonUp(0)))
		{
            FlipCard();
            //Debug.Log("CLICKED");
		}
    }

    // flip cards
    void FlipCard()
    {
        if (faceUp==false)
        {
            spriteRenderer.sprite = cardFace;
            spriteRenderer.size = new Vector3(cardScale, cardScale, 1);
            levelManager.numFlippedCards++;
            faceUp = true;
        }
        else if (faceUp==true)
        {
            spriteRenderer.sprite = cardBack;
            spriteRenderer.size = new Vector3(cardScale, cardScale, 1);
            levelManager.numFlippedCards--;
            faceUp = false;
        }
    }
}
