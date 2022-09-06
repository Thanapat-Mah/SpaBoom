using System;
using UnityEngine;

public class ShowLeaderboard : MonoBehaviour
{
    [SerializeField] private ScoreUI _scoreUI;

    private void Start()
    {
        _scoreUI.ResetScoreUI();
        _scoreUI.InstantiateScore();
    }

    // public void OnClick_ShowLeaderboard()
    // {
    //     _scoreUI.ResetScoreUI();
    //     _scoreUI.InstantiateScore();
    //     gameObject.SetActive(true);
    // }
}
