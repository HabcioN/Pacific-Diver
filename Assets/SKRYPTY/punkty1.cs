using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class punkty1 : MonoBehaviour
{
    public Text SCORE;
    private int ScoreNum;
    public GameObject VictoryScreen;

    void Start()
    {
        ScoreNum = 0;
        SCORE.text = "SCORE : " + ScoreNum;
    }

    void Update()
    {
        if(ScoreNum == 700)
        {
            VictoryScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D Coin1)
    {
        if(Coin1.tag == "moneta")
        {
            ScoreNum += 50;
            Destroy(Coin1.gameObject);
            UpdateScoreText();
        }
    }

    private void OnDestroy()
    {
        if (gameObject.CompareTag("krab"))
        {
            ScoreNum += 100;
            UpdateScoreText();
        }
    }

    public void AddPoints(int points)
    {
        ScoreNum += points;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        SCORE.text = "SCORE : " + ScoreNum;
    }
}
