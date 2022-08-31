using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public TextMeshProUGUI remainingTimeText;

    private static float _remainingTime = 15;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (_remainingTime <= 0)
        {
            StartCoroutine(TimeOut());
        }
        else
        {
            _remainingTime -= Time.deltaTime;
        }
        remainingTimeText.text = ((int)_remainingTime).ToString();
    }

    IEnumerator TimeOut()
    {
        //Debug.Log("Time out, moving to result...");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
