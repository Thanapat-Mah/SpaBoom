using UnityEngine;

public class ShowLeaderboard : MonoBehaviour
{
    [SerializeField] private ScoreUI _scoreUI;
    
    public void OnClick_ShowLeaderboard()
    {
        _scoreUI.ResetScoreUI();
        _scoreUI.InstantiateScore();
        gameObject.SetActive(true);
    }
}
