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
    
    void start(){
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
}
