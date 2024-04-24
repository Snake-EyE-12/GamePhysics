using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public delegate void OnScoreChange(int amount);
    public static OnScoreChange onScoreChange;
    private int score;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        onScoreChange += AddPoints;
    }

    public void AddPoints(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
