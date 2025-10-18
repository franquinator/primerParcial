using UnityEngine;

public class LivesUI : MonoBehaviour
{
    [SerializeField]
    private GameObject lifeUIPrefab;
    private int numLives;
    // Start is called before the first frame update
    void Start()
    {
        numLives = GameManager.instance.Lives;
        AddVisualLives(numLives);
    }
    void Update()
    {
        if (numLives != GameManager.instance.Lives)
        {
            numLives = GameManager.instance.Lives;
            SetVisualLives(numLives);
        }
    }
    private void AddVisualLives(int numAddLives)
    {
        for (int i = 0; i < numAddLives; i++)
        {
            Instantiate(lifeUIPrefab, transform);
        }
    }
    private void RemoveVisualLives(int numRemoveLives)
    {
        //limita la cantidad de vidas a borrar a la cantidad de vidas total
        //por ejemplo si hay 2 vidas y quiero borrar 10 solo borra las que hay
        int livesToErase = Mathf.Min(numLives, numRemoveLives);
        for (int i = 0; i < livesToErase; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
    private void SetVisualLives(int numSetLives)
    {
        int livesDiference = Mathf.Abs(numSetLives - transform.childCount);
        if (numSetLives < transform.childCount)
        {
            RemoveVisualLives(livesDiference);
        }
        else
        {
            AddVisualLives(livesDiference);
        }
    }


}
