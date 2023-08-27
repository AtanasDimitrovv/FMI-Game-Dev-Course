using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownTower : MonoBehaviour
{
    private Tower tower;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(EnemyController enemy in tower.enemiesInRange)
        {
            enemy.speedModifier = tower.fireRate;
            enemy.isSlowed = true;
        }
    }
}
