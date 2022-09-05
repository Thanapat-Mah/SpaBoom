using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackRate = 1;
    public PlayerProjectile bulletPrefab;
    public LevelController levelController;

    private float coolDown;
    private bool _iscoolDown;
    void start(){
        coolDown = 0;
        _iscoolDown = false;
        print("Text I want to write to Unity console");
    }
    void update()
    {
        print("Text I want to write to Unity console");
        if (Input.GetMouseButtonDown(0)){
            print("Text I want to write to Unity console");
        }
        if (Input.GetMouseButtonDown(0) && levelController.AllowPlayerShoot() && _iscoolDown == false){
            ShootBullet();
            _iscoolDown = true;
        }
        if(_iscoolDown == true){
            coolDown+=Time.deltaTime;
            if(coolDown >= attackRate){
                _iscoolDown = false;
            }
        }
    }

    private void ShootBullet()
    {
        Instantiate(this.bulletPrefab, transform.position, Quaternion.identity);
    }
}
