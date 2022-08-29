using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Movement speed
    public float speed;
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
        transform.Rotate(new Vector3(0f, 0f, speed)*Time.deltaTime);
        if(timer >= changeTime){
            if(Random.value <= (percentChange/100)){
                speed = -speed;
            }
            timer = 0;
        }
    }
}
