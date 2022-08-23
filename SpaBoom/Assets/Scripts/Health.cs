using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] hearts;
    public int remainingHealth = 3;

    void Start()
    {
    }
    
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < remainingHealth)
            {
                hearts[i].color = Color.red;
            } else {
                hearts[i].color = Color.white;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        remainingHealth--;
    }
}
