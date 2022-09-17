using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OnClick_MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void OnClick_StartGame()
    {
        ScoreManager.Instance.StartScore();
    }
}
