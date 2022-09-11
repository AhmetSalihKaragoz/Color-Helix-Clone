using System;
using TMPro;
using UnityEngine;


public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper Instance;
    
    private TextMeshProUGUI _scoreText;
    private int _score;
    
    private void Start()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
        PlayerPrefs.GetInt("score", _score);
        _scoreText.text = _score.ToString();
    }
    
    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int newScore)
    {
        _score = newScore;
        _scoreText.text = _score.ToString();
        PlayerPrefs.SetInt("score", _score);
    }

}
