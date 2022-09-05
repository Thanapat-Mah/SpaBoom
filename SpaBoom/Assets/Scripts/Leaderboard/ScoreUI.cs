using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private RowUI rowUI;
    [SerializeField] private List<GameObject> medal;

    public void ResetScoreUI()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void InstantiateScore()
    {
        var playerScores = LeaderBoardManager.Instance.GetHighScore().ToArray();
        for (int i = 0; i < playerScores.Length && i < 5; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            if (i < 3)
                Instantiate(medal[i], row.rank.transform);
            row.rank.text = (i + 1).ToString();
            row.name.text = playerScores[i].name;
            row.score.text = playerScores[i].score.ToString();
        }
    }
}
