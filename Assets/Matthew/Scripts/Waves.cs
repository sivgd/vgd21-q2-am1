using System.Collections;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public static int enemiesAlive;
    public WaveHandler[] wavesVar;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public PathCreation.PathCreator spawnPath;
    public Transform spawnPoint;
    public Transform enemyParent;
    public GameObject healthBarPrefab;
    public GameObject cabbageCounter;
    public float enemyFlashTime;
    private void Start()
    {
       
    }
    private void Update()
    {

        if(enemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming");

        WaveHandler wave = wavesVar[waveIndex];
        if (wave.firstEnemy != null)
        {
            for (int i = 0; i < wave.firstCount; i++)
            {
                SpawnEnemy(wave.firstEnemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        if (wave.secondEnemy != null)
        {
            for (int i = 0; i < wave.secondCount; i++)
            {
                SpawnEnemy(wave.secondEnemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        if (wave.thirdEnemy != null)
        {
            for (int i = 0; i < wave.thirdCount; i++)
            {
                SpawnEnemy(wave.thirdEnemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        if (wave.fourthEnemy != null)
        {
            for (int i = 0; i < wave.fourthCount; i++)
            {
                SpawnEnemy(wave.fourthEnemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        GameObject enemyAccess = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation, enemyParent);
        enemyAccess.GetComponent<PathCreation.Examples.PathFollower>().pathCreator = spawnPath;
        GameObject healthBar = Instantiate(healthBarPrefab, enemyAccess.transform);
        healthBar.GetComponent<HealthBar>().attachedEnemy = enemyAccess;
        enemyAccess.GetComponent<EnemyHealth>().cabbageCounter = cabbageCounter;
        enemyAccess.GetComponent<EnemyHealth>().flashTime = enemyFlashTime;
        enemyAccess.GetComponent<EnemyHealth>().healthBar = healthBar;
        enemiesAlive++;
    }
}
