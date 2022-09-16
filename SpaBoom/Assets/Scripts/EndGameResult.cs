using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    private int score;
    private PlayerScore playerScore;

    private void Start()
    {
        score = ScoreManager.Instance.GetScore();
    }

    public void OnClick_ChangeToLeaderboardScene()
    {
        LeaderBoardManager.Instance.AddScore(new PlayerScore(playerName.text, score));
        // LeaderBoardManager.Instance.CreateLeaderboard();
        SceneManager.LoadScene("Leaderboard");
    }
}
