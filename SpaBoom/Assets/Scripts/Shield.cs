using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{ 
    public Health health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // add score only when the health not empty yet
        if (health.GetRemainingHealth() > 0)
        {
            if (collision.gameObject.tag == "NormalBullet")
            {
                ScoreManager.Instance.AddScore(10);
            }
            else if (collision.gameObject.tag == "BossBullet")
            {
                ScoreManager.Instance.AddScore(15);
            }
        }
    }

    public void SetActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }
}