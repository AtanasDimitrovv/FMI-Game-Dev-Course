using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public EnemyController[] enemiesToSpawn;

    public Transform spawnPoint;

    public float timeBetweenSpawns;
    private float spawnCounter;

    public int amountToSpawn = 15;

    public Castle castle;
    public Path path;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (amountToSpawn > 0 && LevelManager.instance.levelIsActive)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;

                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint.position, spawnPoint.rotation).Setup(castle, path);

                amountToSpawn--;

            }
        }
    }
}
