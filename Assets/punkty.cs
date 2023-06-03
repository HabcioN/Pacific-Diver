using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int pointValue = 10;
    private int score = 0;
    private Text pointsText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        pointsText = GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            score += pointValue;
            UpdatePointsText();
            Destroy(gameObject);
        }
    }

    private void UpdatePointsText()
    {
        pointsText.text = "Points: " + score.ToString();
    }
}
