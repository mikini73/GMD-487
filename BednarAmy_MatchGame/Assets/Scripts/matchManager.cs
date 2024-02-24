using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class matchManager : MonoBehaviour
{
    public int noOfClick = 0;

    public Image firstImageClicked, secondImageClicked;
    public static matchManager instance;
    public Sprite emptyTile;
    public scoreManager scoreManage;
    private void Awake()
    {
        instance=this;
    }

    public void clickedOnImage(Image obj)
    {
        if (firstImageClicked == null)
        {
            firstImageClicked = obj;
            noOfClick++;
        }
        else
        {
            secondImageClicked = obj;
            noOfClick++;
            Invoke("checkMatch", 1);
           
            
        }
        
   
    }

    public void checkMatch()
    {
        if(firstImageClicked.sprite==secondImageClicked.sprite)
        {
            Debug.Log("Match");
            Destroy(firstImageClicked.transform.parent.gameObject);
            Destroy(secondImageClicked.transform.parent.gameObject);
            //firstImageClicked.sprite = emptyTile;
            //secondImageClicked.sprite = emptyTile;
            firstImageClicked = null;
            secondImageClicked = null;
            scoreManage.incrementScore();
            noOfClick = 0;
        }
        else
        {
            Debug.Log("Not Match");
            firstImageClicked.sprite = emptyTile;
            secondImageClicked.sprite = emptyTile;
            firstImageClicked = null;
            secondImageClicked = null;
            noOfClick = 0;
        }
    }
}
