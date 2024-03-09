using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageFlipper : MonoBehaviour
{
   
    public float revealTime = 2f; // Time to reveal the images before flipping them back
    public Sprite backImage;        //red image with border, shows when Tile is upside down
    private Sprite frontImage;      //  Shows when tile is right side up
    private List<SpriteRenderer> tiles = new List<SpriteRenderer>();
    public Image spriteBack;        //from generated insert
    public Sprite[] icons;          //Insert number of icons/Insert Sprites
    private bool isClickable = false;
    void Start()
    {
        StartCoroutine(ShowImages());
    }

    IEnumerator ShowImages()
    {

        spriteBack.sprite = icons[Random.Range(0,13)];   // Random Sprite is generated
        frontImage = spriteBack.sprite;                 // Random Sprite becomes frontImage
        yield return new WaitForSeconds(revealTime);    //Reveal time is pulled from public Reveal Time
        spriteBack.sprite = backImage;
        // Random Sprite is hidden
        isClickable = true;
    }

    public void onClick() //If card is clicked, makes from enriched become the icon, for up to two clicks
    {
        if (isClickable == true)
        {
            if (matchManager.instance.noOfClick < 2)
            {
                Debug.Log("clicked");

                spriteBack.sprite = frontImage;

                matchManager.instance.clickedOnImage(spriteBack);
            }
        }
    }
}
