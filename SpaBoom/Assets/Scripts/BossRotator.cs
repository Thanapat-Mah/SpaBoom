using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotator : MonoBehaviour
{
    //Changed angle
    public float angle;
    //Time in second before randomly change direction
    public float changeTime;
    //Percent to randomly change direction
    public float percentChange;
    
    private float timer;

    void Start(){
        //enabled = false;
        this.gameObject.SetActive(false);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer >= changeTime){
            transform.Rotate(new Vector3(0f, 0f, angle));
            if(Random.value <= (percentChange/100)){
                angle = -angle;
            }
            timer = 0;
        }
    }

    public void SetActive()
    {
        this.gameObject.SetActive(true);
    }
}
