using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float attackRate = 1;
    public PlayerProjectile bulletPrefab;
    public LevelController levelController;
    public GameObject spawnPoint;

    private float coolDown;
    private bool _iscoolDown;
    void start(){
        coolDown = 0;
        _iscoolDown = false;
    }
    void Update()
    {
        // calculate angle to rotate
        Vector3 orbVector = Camera.main.WorldToScreenPoint(transform.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

        // rotate the object according to calculated angle
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Attack in attack phase and click and not in cooldown
        if (Input.GetMouseButtonDown(0) && !_iscoolDown && levelController.AllowPlayerShoot()){
            _iscoolDown = true;
            ShootBullet();
        }
        if(_iscoolDown){
            coolDown+=Time.deltaTime;
            if(coolDown >= attackRate){
                coolDown = 0;
                _iscoolDown = false;
            }
        }
    }
    private void ShootBullet()
    {
        Instantiate(this.bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}