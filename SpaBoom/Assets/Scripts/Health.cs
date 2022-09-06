using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image[] hearts;
    private int _remainingHealth = 3;

    void Start()
    {
    }
    
    void Update()
    {
        // display current ramaining health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < _remainingHealth)
            {
                hearts[i].color = Color.red;
            } else {
                hearts[i].color = Color.white;
            }
        }
    }

    public int GetRemainingHealth()
    {
        return _remainingHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _remainingHealth--;
        if (_remainingHealth <= 0)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        //Debug.Log("Player dead, moving to result...");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Result");
    }
}
