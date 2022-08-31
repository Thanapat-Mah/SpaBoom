using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public TextMeshProUGUI remainingTimeText;
    public TextMeshProUGUI wave;

    private static bool _isGameRun;
    private static float _remainingTime;
    private static bool _isDefendPhase;
    private static int _wave;

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
        _isGameRun = true;
        _remainingTime = 10f;
        _isDefendPhase = true;
        _wave = 1;
    }

    private void Update()
    {
        if (!_isGameRun)
        {
            return;
        }
        // when time out in defend phase of wave 3, game over
        if (_remainingTime <= 0.3 &&
            _isDefendPhase &&
            _wave == 3)
        {
            StartCoroutine(GameOver());
        }
        // if timeout, switch phase
        else if (_remainingTime <= 0.3)
        {
            StartCoroutine(SwitchPhase());
        }
        // else, continuous decrease time
        else
        {
            _remainingTime -= Time.deltaTime;
        }
        // display remaining time and current wave
        remainingTimeText.text = ((int)_remainingTime).ToString();
        wave.text = _wave.ToString();
    }

    public bool GetIsGameRun()
    {
        return _isGameRun;
    }

    static IEnumerator SwitchPhase()
    {
        _isGameRun = false;
        yield return new WaitForSeconds(1);
        if (!_isDefendPhase)
        {
            _wave++;                        // increase wave if previous phase is attack phase
        }        
        _isDefendPhase = !_isDefendPhase;   // switch phase
        if (_isDefendPhase)
        {
            _remainingTime = 10f;           // 30 secs for defend phase
        }
        else
        {
            _remainingTime = 5f;           // 15 secs for attack phase
        }
        _isGameRun = true;
    }

    static IEnumerator GameOver()
    {
        _isGameRun = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
        _isGameRun = true;
    }
}
