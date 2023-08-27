using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : MonoBehaviour
{
    private Tower tower;

    private float bombCounter;

    public Bomb bomb;

    public Transform spawnPoint;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();

        bombCounter = tower.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        bombCounter -= Time.deltaTime;

        if (tower.enemiesInRange.Count > 0)
        {
            if (bombCounter <= 0)
            {
                float minDistance = tower.range + 1f;

                foreach (EnemyController enemy in tower.enemiesInRange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                        }
                    }
                }

                bombCounter = tower.fireRate;

                Bomb newBomb = Instantiate(bomb, spawnPoint.position, Quaternion.identity);
                newBomb.targetPoint = target.position;
            }
        }
    }
}
