using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;

    public bool result;
    
    // Start is called before the first frame update
    void Start()
    {
       
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        if (result == true)
        {
            winScreen.SetActive(true);
        }

        else
        {
            loseScreen.SetActive(true);
        }
    }
}
