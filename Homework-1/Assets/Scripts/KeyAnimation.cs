using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyAnimation : MonoBehaviour
{

    public int numberOfKeys;

    [SerializeField]
    private Image[] keys;
    public Sprite fullKey;
    public Sprite emptyKey;

    public int currentKey;

    public void Start()
    {
        for(int i = 0; i < keys.Length; i++)
        {
            if (i < numberOfKeys)
            {
                keys[i].enabled = true;
            } else
            {
                keys[i].enabled = false;
            }
        }

        currentKey = 0;
    }

    public void collectKey()
    {
        if (currentKey < numberOfKeys)
        {
            keys[currentKey].sprite = fullKey;
            currentKey++;
        }
    }
}
