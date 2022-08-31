using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image[] hearts;
    public int remainingHealth = 3;

    void Start()
    {
    }
    
    void Update()
    {
        // display current ramaining health
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
        if (remainingHealth <= 0)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        Debug.Log("Player dead, moving to result...");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
