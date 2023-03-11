using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGroundTrigger : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.GetComponent<CharMovement>().StepOnGround();
        }
    }
}
