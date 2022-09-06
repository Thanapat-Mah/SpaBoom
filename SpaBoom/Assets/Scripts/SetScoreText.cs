using TMPro;
using UnityEngine;

public class SetScoreText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    
    private void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(scoreText != null)
            scoreText.text = ScoreManager.Instance.GetScore().ToString();
    }
}
