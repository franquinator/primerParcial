using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    [SerializeField]
    private string menuSceneName;
    public void Restart()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void Exit()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
