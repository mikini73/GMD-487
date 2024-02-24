using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageFlipper : MonoBehaviour
{
   
    public float revealTime = 2f; // Time to reveal the images before flipping them back
    public Sprite backImage;
    private Sprite frontImage;
    private List<SpriteRenderer> tiles = new List<SpriteRenderer>();
    public Image spriteBack;
    public Sprite[] icons;
    void Start()
    {
        StartCoroutine(ShowImages());
    }

    IEnumerator ShowImages()
    {

        spriteBack.sprite = icons[Random.Range(0,3)];
        frontImage = spriteBack.sprite;
        yield return new WaitForSeconds(revealTime);   
        spriteBack.sprite = backImage;    
    }

    public void onClick()
    {
        if (matchManager.instance.noOfClick < 2)
        {
            Debug.Log("clicked");

            spriteBack.sprite = frontImage;

            matchManager.instance.clickedOnImage(spriteBack);
        }
    }
}
