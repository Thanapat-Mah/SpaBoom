using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Movement speed
    public float startSpeed;
    private float speed;
    public float speedIncreasePercent;
    //Time in second before randomly change direction
    public float changeTime;
    //Percent to randomly change direction
    public float percentChange;

    private float timer;
    
    void Start()
    {
        speed = (float)(startSpeed + startSpeed * speedIncreasePercent / 100 * (LevelController.Instance.GetWave() - 1));
        timer = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        // speed = Mathf.RoundToInt(speedCurve.Evaluate(LevelController.Instance.));
        if (!LevelController.Instance.GetIsGameRun())
        {
            return;
        }
        timer+=Time.deltaTime;
        transform.Rotate(new Vector3(0f, 0f, speed)*Time.deltaTime);
        if(timer >= changeTime){
            speed = (float)(startSpeed + startSpeed * speedIncreasePercent / 100 * (LevelController.Instance.GetWave() - 1));
            if(Random.value <= (percentChange/100)){
                speed = -speed;
            }
            timer = 0;
        }
    }
}
