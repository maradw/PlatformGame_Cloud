using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager_Platform : MonoBehaviour
{
    [SerializeField] int score;

    


    [SerializeField] private TextMeshProUGUI scoreText;





    /*void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Save Progress"))
        {
            
        }
    }*/



    void OnEnable()
    {
        PlayerController.OnCollisionItem += CurrentScore;
    }
    private void OnDisable()
    {
        PlayerController.OnCollisionItem -= CurrentScore;
    }
    private void Update()
    {
        scoreText.text = "Score: " + score;

       
    }
    public void CurrentScore(int numb)
    {
        score = score + numb;


    }
}
