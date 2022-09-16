using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;

    private static int _score;
    
    public void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }
        
    private void Start()
    {
        //enabled = false;
    }
    
    private void Update()
    {
        if (_score < 0)
            _score = 0;
        if (scoreText != null)
        {
            scoreText.text = _score.ToString();
        }
    }
        
    public void StartScore()
    {
        enabled = true;
        _score = 0;
    }
        
    public int GetScore()
    {
        return _score;
    }
    
    public void AddScore(int scoreGain)
    {
        _score += scoreGain;
    }
}
