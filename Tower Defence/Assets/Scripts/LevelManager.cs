using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool levelIsActive;
    private bool victory;

    private Castle castle;

    public List<EnemyHealth> activeEnemies = new List<EnemyHealth>();

    private EnemyWaveSpawner enemySpawner;

    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        castle = FindObjectOfType<Castle>();
        enemySpawner = FindObjectOfType<EnemyWaveSpawner>();
        levelIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelIsActive)
        {
            if (castle.currHealth <= 0)
            {
                levelIsActive = false;
                victory = false;

                UIController.instance.towerButtons.SetActive(false);
            }

            if (activeEnemies.Count == 0 && !enemySpawner.shouldSpawn)
            {
                levelIsActive = false;
                victory = true;

                UIController.instance.towerButtons.SetActive(false);
            }

            if (!levelIsActive)
            {
                UIController.instance.levelFailed.SetActive(!victory);
                UIController.instance.levelCompleted.SetActive(victory);

                UIController.instance.CloseTowerUpgradePanel();
            }
        }
    }
}
