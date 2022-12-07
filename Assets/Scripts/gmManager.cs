using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gmManager : MonoBehaviour
{
    Canvas HUD;
    Text scoreVal;
    Text highscoreVal;
    void Start()
    {
        HUD = Canvas.FindObjectOfType<Canvas>();
        HUD.enabled = true;
        scoreVal = GameObject.Find("scoreValue").GetComponent<Text>();
        scoreVal.text = "0";
        highscoreVal = GameObject.Find("highscoreValue").GetComponent<Text>();


        StartCoroutine(AddScore());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            HUD.enabled=!HUD.enabled;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainMenu");
        }

    }

    IEnumerator AddScore()
    {
        yield return new WaitForSeconds(1);
        scoreVal.text = Convert.ToString(Convert.ToInt32(scoreVal.text) + 1);
        if(Convert.ToInt32(scoreVal.text)> Convert.ToInt32(highscoreVal.text))
        {
            highscoreVal.text = scoreVal.text;
        }

        StartCoroutine(AddScore());
    }
}
