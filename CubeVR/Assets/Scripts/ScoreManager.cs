using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; //singleton to refer this script later on

    [SerializeField] private TextMeshProUGUI scoreText;

    private float score;


    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(float points)
    {
        score += points;
        scoreText.text = $"Score: {score}";
    }
}
