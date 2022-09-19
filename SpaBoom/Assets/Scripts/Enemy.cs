using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startAtkRate = 1;
    private float attackRate;
    public float atkRateIncreasePercent;
    public Projectile bulletPrefab;
    public int score;
    private float timePass = 0;

    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), this.attackRate, this.attackRate);
    }

    private void Update()
    {
        timePass += Time.deltaTime;
        // Debug.Log(timePlayed);
        attackRate = startAtkRate -
                     (startAtkRate * atkRateIncreasePercent / 100 * (LevelController.Instance.GetWave() - 1));
        if (timePass > attackRate)
        {
            ShootBullet();
            timePass = 0;
        }
    }

    private void ShootBullet()
    {
        // shoot bullet only if level controller allow
        if (LevelController.Instance.AllowEnemyShooting())
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            Instantiate(this.bulletPrefab, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            ScoreManager.Instance.AddScore(score);
        }
     }
}
