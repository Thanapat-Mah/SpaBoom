using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

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