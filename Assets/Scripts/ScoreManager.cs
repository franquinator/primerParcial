using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // (Singleton)

    // Variables globales del juego
    public int score = 0;
    public int scorePerKill = 100;
    [SerializeField]
    private TMP_Text scoreUI;


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject); // Evitar duplicados
        SetScoreUI();
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
        SetScoreUI();
    }
    public void AddScorePerKill()
    {
        score += scorePerKill;
        SetScoreUI();
    }
    private void SetScoreUI()
    {
        scoreUI.text = "Score: " + score;
    }

    public void ResetGame()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
