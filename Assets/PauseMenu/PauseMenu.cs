using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;  
    private bool Activo;
    [SerializeField]
    private string menuSceneName;
    private void Awake()
    {
        Panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Activo)
        {
            Activo = false;
            Time.timeScale = 1;
            Panel.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Activo = true;
            Time.timeScale = 0.005f;
            Panel.SetActive(true);
        }
    } 
    public void Continuar()
    {
        Activo = false;
        Time.timeScale = 1;
        Panel.SetActive(false);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
        Time.timeScale = 1;
    }
}
