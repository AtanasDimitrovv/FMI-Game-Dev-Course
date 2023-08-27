using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradePanel : MonoBehaviour
{
    public GameObject rangeButton;
    public GameObject fireRateButton;
    public TMP_Text rangeText;
    public TMP_Text fireRateText;

    public void SetupPanel()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (TowerManager.instance.selectedTower.upgrader.hasRangeUpgrade)
        {
            rangeText.text = "Upgrade\nRange\n(" + upgrader.rangeUpgrades[upgrader.currRangeUpgrade].cost + "g)";

            rangeButton.SetActive(true);
        } else
        {
            rangeButton.SetActive(false);
        }

        if (TowerManager.instance.selectedTower.upgrader.hasFireRateUpgrade)
        {
            fireRateText.text = "Upgrade\nFire Rate\n(" + upgrader.fireRateUpgrades[upgrader.currFireRateUpgrade].cost + "g)";

            fireRateButton.SetActive(true);
        }
        else
        {
            fireRateButton.SetActive(false);
        }
    }

    public void RemoveTower()
    {
        MoneyManager.instance.GiveMoney(50);

        Destroy(TowerManager.instance.selectedTower.gameObject);

        UIController.instance.CloseTowerUpgradePanel();
    }

    public void UpgradeRange()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasRangeUpgrade)
        {
            if(MoneyManager.instance.SpendMoney(upgrader.rangeUpgrades[upgrader.currRangeUpgrade].cost))
            {
                upgrader.UpgradeRange();

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);
            } else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }
        }
    }

    public void UpgradeFireRate()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasFireRateUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.fireRateUpgrades[upgrader.currFireRateUpgrade].cost))
            {
                upgrader.UpgradeFireRate();

                SetupPanel();

                UIController.instance.notEnoughMoneyWarning.SetActive(false);
            } else
            {
                UIController.instance.notEnoughMoneyWarning.SetActive(true);
            }
        }
    }
}
