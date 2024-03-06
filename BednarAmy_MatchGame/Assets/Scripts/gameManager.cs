﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    //RowTransformPoint is the parent of rowPrefab
    //Insert the place where the rowPrefab will spawn
    public Transform RowTransformPoint;
    //Inset Row Prefab
    public GameObject rowPrefab;
    //The array for the storing of the number of rows
    public GameObject[] rowA;
    //This is the placeholders for the maximum number of rows and columns that you want generated. It shows up inside of above rowA array 
    //in the Inspector, so can be set by you
    [SerializeField] private int m_rows = 0;
    [SerializeField] private int m_columns = 0;


    private void Start()
    {
        //At the beginning of the game we are generating the array and populating it with the number of rows that we select in our maximum row placeholder
        //Fetches The number of rows that we want to generate 
        rowA = new GameObject[m_rows];

        //Instantiates a row from the game object, repeates with the for loop Until it reaches the number of rows
        //It's stored inside the row array
        //It's assigned to the transform RowTransformPoint
        //Adjust the location of the rows

        for (int rows = 0; rows <m_rows; rows++)
        {
            rowA[rows] = Instantiate(rowPrefab);
            rowA[rows].transform.parent = RowTransformPoint;
            rowA[rows].transform.localScale = new Vector3 (1, 1, 1);
            //rowA[rows].GetComponent<HorizontalLayoutGroup>().enabled = false;
            

        }
        //This runs function to clean up the grid
        deleteColumns();
        Invoke("disable", 2);
        
    }
    //This function deletes the extra columns that are generated by the large prefab, Row by row
    public void deleteColumns()
    { 
        for (int rows = 0; rows< m_rows; rows++) {

           for (int column = m_columns; column < rowA[rows].transform.childCount; column++)
           {

               Destroy(rowA[rows].transform.GetChild(column).gameObject);
           
           }

          }
    }

    //Fixes problem with alignment of the rows
    public void disableHorizontalGrid()
    {
        for(int i=0;i<3;i++)
        {
            rowA[i].GetComponent<HorizontalLayoutGroup>().enabled = false;
        }
    }

    //Fixes problem with alignment of the rows
    public void disable()
    {
        disableHorizontalGrid();
    }



    ////Array for storing more different types of pictures(Images); At the moment we have 3 Sugar Gliders
    //public Sprite[] sprites; 
    ////Array for storing all the icons on the grid
    //public Image[] icons; 

    //private void Start()
    //{
    //    //Takes the icons on the grid and places 1 OF 3 sprites on it.
    //    //Random.Range Function makes a random choice between the three icons and chooses one. 
    //    for (int i = 0; i < icons.Length; i++)
    //    {
    //        icons[i].sprite = sprites[Random.Range(0, 3)];   


    //    }
    //}

}
