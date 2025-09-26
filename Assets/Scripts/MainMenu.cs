using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject controlsPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField] 
    private string gameSceneName;
    
    public void Controls()
    {
        controlsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void ExitControls()
    {
        controlsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
