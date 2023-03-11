using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] borders;
    private int currBorderIndex = 0;

    private float moveSpeed = 3f;

    private void Update()
    {
        if (Vector2.Distance(borders[currBorderIndex].transform.position, transform.position) < 0.1f)
        {
            currBorderIndex++;
            currBorderIndex = currBorderIndex % 2;
        }

        transform.position = Vector2.MoveTowards(transform.position, borders[currBorderIndex].transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
