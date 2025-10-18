using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    private bool active;
    private void Awake()
    {
        panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && active)
        {
            Continue();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    void OnDisable()
    {
        Continue();
    }

    public void Pause()
    {
        active = true;
        Time.timeScale = 0;
        panel.SetActive(true);
    }
    public void Continue()
    {
        active = false;
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
