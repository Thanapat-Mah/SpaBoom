using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float attackRate = 1;
    public PlayerProjectile bulletPrefab;
    public LevelController levelController;
    public GameObject spawnPoint;
    
    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), this.attackRate, this.attackRate);
    }
    private void ShootBullet()
    {
        if (levelController.AllowPlayerShoot())
        {
            Instantiate(this.bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
    public void SetActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }
}
