using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreUI : MonoBehaviour
{
    private TMP_Text _TMPtext;
    void Start()
    {
        _TMPtext = gameObject.GetComponent<TMP_Text>();
    }
    void Update()
    {
        _TMPtext.text = "Score: " + GameManager.instance.Score;
    }
}
