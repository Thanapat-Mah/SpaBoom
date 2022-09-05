using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackRate = 1;
    public ScoreManager scoreManager;
    public Projectile bulletPrefab;
    public LevelController levelController;
    public int score;

    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), this.attackRate, this.attackRate);
    }

    private void ShootBullet()
    {
        // shoot bullet only if level controller allow
        if (levelController.AllowEneyShooting())
        {
            Instantiate(this.bulletPrefab, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            scoreManager.AddScore(score);
        }
     }
}
