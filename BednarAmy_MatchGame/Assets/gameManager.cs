using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    //Array for more story different types of pictures(Images); At the moment we have 3 Sugar Gliders
    public Sprite[] sprites; 
    //Array for storing all the icons on the grid
    public Image[] icons; 

    private void Start()
    {
        //Takes the icons on the grid and places 1 OF 3 sprites on it.
        //Random.Range Function makes a random choice between the three icons and chooses one. 
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].sprite = sprites[Random.Range(0, 3)];   
            

        }
    }
    private void Update()
    {
        
    }

}
