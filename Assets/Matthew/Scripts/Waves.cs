using System.Collections;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;
    public PathCreation.PathCreator spawnPath;
    public Transform spawnPoint;
    public Transform enemyParent;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming");
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, enemyParent);
        enemy.GetComponent<PathCreation.Examples.PathFollower>().pathCreator = spawnPath;
    }
}
