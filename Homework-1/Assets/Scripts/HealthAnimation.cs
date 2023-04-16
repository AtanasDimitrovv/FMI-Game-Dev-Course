using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthAnimation : MonoBehaviour
{
    public int numberOfHearts;

    [SerializeField]
    private Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int currentHeart;

    public void Start()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        currentHeart = numberOfHearts;
    }

    public void takeDamage()
    {
        if (currentHeart >= 0)
        {
            hearts[currentHeart].sprite = emptyHeart;
            currentHeart--;
        }

        if (currentHeart < 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
