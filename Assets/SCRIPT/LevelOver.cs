using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelOver : MonoBehaviour
{
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] TextMeshProUGUI ScoreText;

    [SerializeField] int coinrating;
    [SerializeField] int totalcoin;
    [SerializeField] int score;

    void Start()
    {
        score = ScoreManager.score;
        totalcoin = GameObject.FindGameObjectsWithTag("Coin").Length+score;
        coinrating = Mathf.RoundToInt((float)score / totalcoin) * 3;
        ScoreText.text = score.ToString();

        if (coinrating==2)
        {
            star2.SetActive(true);
        }

        if (coinrating == 3)
        {
            star2.SetActive(true);
            star3.SetActive(true);
        }
    }
}
