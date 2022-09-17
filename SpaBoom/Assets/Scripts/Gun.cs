using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static float attackInterval = 0.5f;
    public PlayerProjectile bulletPrefab;
    public GameObject spawnPoint;

    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), attackInterval, attackInterval);
    }

    private void ShootBullet()
    {
        if (LevelController.Instance.AllowPlayerShoot())
        {
            Instantiate(this.bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    public void SetActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    public void DecreaseAttackInterval(float decreasePercent)
    {
        attackInterval = attackInterval * (1.0f - decreasePercent);
        CancelInvoke();
        InvokeRepeating(nameof(ShootBullet), attackInterval, attackInterval);
    }
}
