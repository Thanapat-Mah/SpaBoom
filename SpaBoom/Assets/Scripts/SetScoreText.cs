using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        if(scoreText != null)
            scoreText.text = ScoreManager.Instance.GetScore().ToString();
    }
}
