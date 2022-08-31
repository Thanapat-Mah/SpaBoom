using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackRate = 1;
    public Projectile bulletPrefab;
    public LevelController levelController;

    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), this.attackRate, this.attackRate);
    }

    private void ShootBullet()
    {
        // shoot bullet only if game phase is defend
        if (levelController.GetIsDefendPhase())
        {
            Instantiate(this.bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
