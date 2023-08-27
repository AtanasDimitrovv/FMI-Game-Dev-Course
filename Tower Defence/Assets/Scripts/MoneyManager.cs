using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int currMoney;

    private void Start()
    {
        UIController.instance.goldText.text = currMoney.ToString();
    }


    public void GiveMoney(int amount)
    {
        currMoney += amount;

        UIController.instance.goldText.text = currMoney.ToString();
    }

    public bool SpendMoney(int amount)
    {
        bool canSpend = false;

        if (amount <= currMoney)
        {
            currMoney -= amount;

            canSpend = true;

            UIController.instance.goldText.text = currMoney.ToString();
        }

        return canSpend;
    }
}
