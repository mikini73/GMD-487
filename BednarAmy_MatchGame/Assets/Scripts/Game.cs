using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    bool MainMenuloaded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MainMenuloaded == true)
            {
                SceneManager.UnloadScene("MainMenu");
                MainMenuloaded = false;
            }
            else
            {
                SceneManager.LoadScene("MainMenu",LoadSceneMode.Additive);
                MainMenuloaded = true;
            }
            
        }
    }
}
