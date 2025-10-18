using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    private int waveSize = 2;
    [SerializeField]
    [Min(0)]
    private int increasedEnemiesByWave = 2;

    [SerializeField]
    private float maxSpawnHeight;
    [SerializeField]
    private float minSpawnHeight;
    [SerializeField]
    private float positionX;

    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    [Min(0)]
    private float minSpawnTime;
    [SerializeField]
    [Min(0)]
    private float maxSpawnTime;
    [SerializeField]
    [Min(0)]
    private float waveDuration;
    [SerializeField]
    [Min(0)]
    private int numberOfWaves;
    [SerializeField]
    [Min(0)]
    private float scoreMultiplier;
    void Start()
    {
        StartCoroutine(CreateWaves());   
    }
    private void OnDrawGizmos()
    {
        Vector2 From = new(positionX, minSpawnHeight);
        Vector2 to = new(positionX, maxSpawnHeight);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(From, to);
    }
    private void CreateEnemy()
    {
        float positionY = Random.Range(minSpawnHeight, maxSpawnHeight);
        Instantiate(enemy, new Vector2(positionX, positionY), enemy.transform.rotation, transform);
    }
    private IEnumerator CreateWaves()
    {
        StartCoroutine(GenerarEnemigos());
        for (int wave = 1; wave < numberOfWaves; wave++)
        {
            yield return new WaitForSeconds(waveDuration);
            GameManager.instance.scorePerKill *= scoreMultiplier;
            Timer.instance.ResetTimer();
            waveSize += increasedEnemiesByWave;
        }
        yield return new WaitForSeconds(waveDuration);
        GameManager.instance.Win();

    }
    private IEnumerator GenerarEnemigos()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            int onScreenEnemies = transform.childCount;
            if (onScreenEnemies < waveSize)
            {
                CreateEnemy();
            }
        }
    }
}
