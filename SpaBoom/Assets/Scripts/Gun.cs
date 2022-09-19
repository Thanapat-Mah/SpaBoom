using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private static float _attackInterval;
    public PlayerProjectile bulletPrefab;
    public GameObject spawnPoint;

    void Start()
    {
        _attackInterval = 0.5f;
        InvokeRepeating(nameof(ShootBullet), _attackInterval, _attackInterval);
    }

    private void ShootBullet()
    {
        if (LevelController.Instance.AllowPlayerShoot())
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            Instantiate(this.bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    public void SetActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    public void DecreaseAttackInterval(float decreasePercent)
    {
        _attackInterval = _attackInterval * (1.0f - decreasePercent);
        CancelInvoke();
        InvokeRepeating(nameof(ShootBullet), _attackInterval, _attackInterval);
    }
}
