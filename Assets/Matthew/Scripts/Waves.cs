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
    public RuntimeAnimatorController standardAttackAnimator;
    public RuntimeAnimatorController speedAttackAnimator;
    public GameObject farm;
    public WaveCounter waveCounter;

    private void Start()
    {
       
    }
    private void Update()
    {

        if(enemiesAlive > 0)
        {
            
            return;
        }else if(enemiesAlive <= 0)
        {
            waveCounter.CheckWave();

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
        if(waveIndex >= wavesVar.Length)
        {
            print("YOU WON");
            yield break;
        }

        Debug.Log("Wave Incoming");
        WaveCounter.waveNumber += 1;
        
        WaveHandler wave = wavesVar[waveIndex];

        waveIndex++;
        for (int i = 0; i < wave.groups.Length; i++)
        {
            
            StartCoroutine(SpawnGroup(wave.groups[i]));
            print("Delay: " + wave.groups[i].delay);
            yield return new WaitForSeconds(wave.groups[i].delay);
        }
        
        /*
        if (wave.firstEnemy != null)
        {
            for (int i = 0; i < wave.firstCount; i++)
            {
                SpawnEnemy(wave.firstGroup);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        if (wave.secondGroup != null)
        {
            for (int i = 0; i < wave.secondCount; i++)
            {
                SpawnEnemy(wave.secondGroup);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        if (wave.thirdGroup != null)
        {
            for (int i = 0; i < wave.thirdCount; i++)
            {
                SpawnEnemy(wave.thirdGroup);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        if (wave.fourthGroup != null)
        {
            for (int i = 0; i < wave.fourthCount; i++)
            {
                SpawnEnemy(wave.fourthGroup);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }*/
        
    }

    IEnumerator SpawnGroup(Group waveGroup)
    {
        for (int e = 0; e < waveGroup.enemyCount; e++)
        {

            SpawnEnemy(waveGroup.enemyPrefab);
            yield return new WaitForSeconds(1f / waveGroup.rate);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        if(enemy == null)
        {
            print("Why is it null?");
            return;
        }
        GameObject enemyAccess = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation, enemyParent);
        enemyAccess.GetComponent<PathCreation.Examples.PathFollower>().pathCreator = spawnPath;
        GameObject healthBar = Instantiate(healthBarPrefab, enemyAccess.transform);
        healthBar.GetComponent<HealthBar>().attachedEnemy = enemyAccess;
        enemyAccess.GetComponent<EnemyHealth>().cabbageCounter = cabbageCounter;
        enemyAccess.GetComponent<EnemyHealth>().flashTime = enemyFlashTime;
        enemyAccess.GetComponent<EnemyHealth>().healthBar = healthBar;
        enemyAccess.GetComponent<EnemyHealth>().farm = farm;
        if (enemyAccess.name == "StandardEnemy(Clone)" || enemyAccess.name == "StandardEnemy2(Clone)" || enemyAccess.name == "StandardEnemy3(Clone)")
        {
            enemyAccess.GetComponent<EnemyHealth>().attackAnimator = standardAttackAnimator;
        }
        else if(enemyAccess.name == "SpeedEnemy(Clone)" || enemyAccess.name == "SpeedEnemy2(Clone)" || enemyAccess.name == "SpeedEnemy3(Clone)")
        {
            enemyAccess.GetComponent<EnemyHealth>().attackAnimator = speedAttackAnimator;
        }
        
        enemiesAlive++;
    }
}
