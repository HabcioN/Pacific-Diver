using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class punkty1 : MonoBehaviour
{
    public Text SCORE;
    private int ScoreNum;

    void Start()
    {
        ScoreNum = 0;
        SCORE.text = "SCORE : " + ScoreNum;
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

    private void UpdateScoreText()
    {
        SCORE.text = "SCORE : " + ScoreNum;
    }
}
