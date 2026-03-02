using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints; // Arrastrá aquí los GameObjects que definen las posiciones

    Wave currentWave;
    int currentWaveNumber;
    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;
    bool allWavesCompleted;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        if (allWavesCompleted) return;

        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawn;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Elegimos un prefab al azar de los definidos en la oleada
        Enemigo prefabAleatorio = currentWave.enemyPrefabs[Random.Range(0, currentWave.enemyPrefabs.Length)];

        // Elegimos un punto de spawn al azar de los definidos en el Spawner
        Transform puntoAleatorio = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Enemigo spawnedEnemy = Instantiate(prefabAleatorio, puntoAleatorio.position, puntoAleatorio.rotation);
        //Me suscribo al evento de muerte del enemigo para llevar la cuenta de los enemigos vivos
        spawnedEnemy.OnDeath += OnEnemyDeath;
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;

        if (enemiesRemainingAlive <= 0 && enemiesRemainingToSpawn <= 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        if (currentWaveNumber >= waves.Length)
        {
            allWavesCompleted = true;
            Debug.Log("¡Todas las oleadas completadas!");
            return;
        }

        currentWave = waves[currentWaveNumber];
        currentWaveNumber++;

        enemiesRemainingToSpawn = currentWave.enemyCount;
        enemiesRemainingAlive   = currentWave.enemyCount;

        Debug.Log("Oleada " + currentWaveNumber + " iniciada");
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawn;
        public Enemigo[] enemyPrefabs; // Uno o varios prefabs por oleada
    }
}