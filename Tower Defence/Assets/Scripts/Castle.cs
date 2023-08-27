using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float totalHealth = 100f;
    [HideInInspector]
    public float currHealth;

    public Slider healthSlider;

    public Transform[] attackPoints;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = totalHealth;

        healthSlider.maxValue = totalHealth;
        healthSlider.value = currHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            currHealth = 0;
            gameObject.SetActive(false);
        }

        healthSlider.value = currHealth;
    }
}
