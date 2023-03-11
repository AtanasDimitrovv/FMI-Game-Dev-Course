using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostJump : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<CharMovement>().StepOnBooster();
        }
    }
}