using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour
{
    public static LeaderBoardManager Instance;

    private static List<PlayerScore> PS;
    
    // [SerializeField] private ScoreUI _scoreUI;
    
    public void Awake()
    {
        PS ??= new List<PlayerScore>();
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        for (int i = 0; i < PS.Count && i < 10; i++)
        {
            Debug.Log(PS[i].name);
        }
    }

    public IEnumerable<PlayerScore> GetHighScore()
    {
        return PS.OrderByDescending(x => x.score);
    }

    public void AddScore(PlayerScore playerScore)
    {
        PS.Add(playerScore);
    }

    // public void CreateLeaderboard()
    // {
    //     _scoreUI.ResetScoreUI();
    //     _scoreUI.InstantiateScore();
    // }
}
