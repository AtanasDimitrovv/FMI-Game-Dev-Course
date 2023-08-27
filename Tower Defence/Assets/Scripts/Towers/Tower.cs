using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public float fireRate;
    public LayerMask enemyMask;

    private Collider[] collidersInRange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>();

    private float checkCounter;
    public float checkTime = 0.2f;

    [HideInInspector]
    public bool enemiesUpdated;

    public GameObject rangeModel;

    public int cost = 100;

    [HideInInspector]
    public TowerUpgradeController upgrader;

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;

        upgrader = GetComponent<TowerUpgradeController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdated = false;

        checkCounter -= Time.deltaTime;
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;

            collidersInRange = Physics.OverlapSphere(transform.position, range, enemyMask);

            enemiesInRange.Clear();
            foreach (Collider col in collidersInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }

            enemiesUpdated = true;
        }

        if (TowerManager.instance.selectedTower == this)
        {
            rangeModel.SetActive(true);
            rangeModel.transform.localScale = new Vector3(range, 1f, range);
        }
    }

    private void OnMouseDown()
    {
        if (TowerManager.instance.selectedTower != null)
        {
            TowerManager.instance.selectedTower.rangeModel.SetActive(false);
        }
        TowerManager.instance.selectedTower = this;

        UIController.instance.OpenTowerUpgradePanel();

        TowerManager.instance.MoveTowerSelectionEffect();
    }
}
