using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int lives;
    public int Lives { get { return lives; } }
    [SerializeField]
    [Range(1, 7)]
    private int maxLives = 1;
    private int score = 0;
    public int Score { get { return score; } }
    [HideInInspector]
    public float scorePerKill = 100;
    [SerializeField]
    private float initialScorePerKill;
    [SerializeField]
    private AudioClip damageReceivedSound, gameOverSound;
    [SerializeField]
    private string gameOverSceneName, winSceneName, gameplaySceneName, menuScene;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else Destroy(gameObject);
    }
    public void Start()
    {
        lives = maxLives;
        scorePerKill = initialScorePerKill;
    }

    public void RemoveLives(int numLives)
    {
        lives -= numLives;
        AudioManager.instance.PlayAudioClip(damageReceivedSound);
        if (lives <= 0)
        {
            Lose();

        }
    }
    public void AddScore(int addedScore)
    {
        score += addedScore;
    }
    public void AddScorePerKill()
    {
        score += (int)scorePerKill;
    }

    public void Win()
    {
        SceneManager.LoadScene(winSceneName);
    }
    public void Lose()
    {
        AudioManager.instance.PlayAudioClip(gameOverSound);
        SceneManager.LoadScene(gameOverSceneName);
    }
    public void ResetGame()
    {
        score = 0;
        lives = maxLives;
        scorePerKill = initialScorePerKill;
        SceneManager.LoadScene(gameplaySceneName);
    }
    public void QuitMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
