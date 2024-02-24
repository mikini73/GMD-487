using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoreManager : MonoBehaviour
{
    public int scores;
    public TextMeshProUGUI scoreTxt;
    public static scoreManager instance;


    private void Awake()
    {
        
    }

    public void incrementScore()
    {
        scores+= 10;
        scoreTxt.text = scores.ToString();
    }
}
