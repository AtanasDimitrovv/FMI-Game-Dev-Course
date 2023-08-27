using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    private Tower tower;

    public UpgradeStage[] rangeUpgrades;
    [HideInInspector]
    public int currRangeUpgrade;
    [HideInInspector]
    public bool hasRangeUpgrade = true;

    public UpgradeStage[] fireRateUpgrades;
    [HideInInspector]
    public int currFireRateUpgrade;
    [HideInInspector]
    public bool hasFireRateUpgrade = true;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
    }

    public void UpgradeRange()
    {
        tower.range = rangeUpgrades[currRangeUpgrade].amount;
        currRangeUpgrade++;

        if (currRangeUpgrade >= rangeUpgrades.Length)
        {
            hasRangeUpgrade = false;
        }
    }

    public void UpgradeFireRate()
    {
        tower.fireRate = fireRateUpgrades[currFireRateUpgrade].amount;
        currFireRateUpgrade++;

        if (currFireRateUpgrade >= fireRateUpgrades.Length)
        {
            hasFireRateUpgrade = false;
        }
    }
}

[System.Serializable]
public class UpgradeStage
{
    public float amount;
    public int cost;
}