using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public bool HasStarted { get; set; }
    public bool HasScoredPerfect { get; set; }
    public bool HasScoredNormal { get; set; }
    
    private ScoreKeeper _scoreKeeper;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void UpdateScoreText()
    {
        GetNormalScore();
        GetPerfectScore();
    }

    private void GetNormalScore()
    {
        _scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
        if (!HasScoredNormal) return;
        _scoreKeeper.SetScore(_scoreKeeper.GetScore() + 2);
        HasScoredNormal = false;
    }

    private void GetPerfectScore()
    {
        _scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
        if (HasScoredPerfect)
        {
            _scoreKeeper.SetScore(_scoreKeeper.GetScore() + 4);
            HasScoredPerfect = false;
        }
        
    }
    
}
