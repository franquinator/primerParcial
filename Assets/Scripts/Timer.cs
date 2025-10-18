using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;
    private float timeElapsed;
    public static Timer instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        int minutes = (int)(timeElapsed / 60f);
        int seconds = (int)(timeElapsed - minutes * 60f);
        int cents = (int)((timeElapsed - (int)timeElapsed) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
    }
    public void ResetTimer()
    {
        timeElapsed = 0;
    }
}
