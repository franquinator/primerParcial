using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    private int lives;
    [SerializeField]
    [Range(1, 7)]
    private int maxLives = 1;
    [SerializeField]
    private GameObject lifeUIPrefab;
    [SerializeField]
    private Transform livesContainer;
    [SerializeField]
    private AudioClip damageReceivedSound;
    [SerializeField]
    private AudioClip gameOverSound;
    [SerializeField]
    private string gameOverSceneName;
    public static HealthManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject); // Evitar duplicados
    }

    void Start()
    {
        lives = maxLives;
        AddVisualLives(lives);
    }

    public void AddVisualLives(int numLives)
    {
        for (int i = 0; i < numLives; i++)
        {
            Instantiate(lifeUIPrefab, livesContainer);
        }
    }
    public void RemoveVisualLives(int numLives)
    {
        //limita la cantidad de vidas a borrar a la cantidad de vidas total
        //por ejemplo si hay 2 vidas y quiero borrar 10 solo borra las que hay
        int livesToErase = Math.Min(lives, numLives);

        for (int i = 0; i < livesToErase; i++)
        {
            Destroy(livesContainer.GetChild(i).gameObject);
        }
    }
    public void RemoveLives(int numLives)
    {
        RemoveVisualLives(numLives);
        lives -= numLives;
        AudioManager.instance.PlayAudioClip(damageReceivedSound);
        if (lives <= 0)
        {
            AudioManager.instance.PlayAudioClip(gameOverSound);
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}
