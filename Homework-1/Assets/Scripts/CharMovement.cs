using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    private bool isOnGround = true;
    private bool shouldJump = false;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpAmount = 7.5f;

    private float boosterJumpAmount = 10.5f;

    private float gravityScale = 1f;
    private float fallingGravityScale = 2.25f;

    private Rigidbody2D rb;

    private GameObject respawnSpot;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnSpot = GameObject.FindWithTag("Respawn");
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            horizontalInput = 1;
        }
        else if (horizontalInput < 0)
        {
            horizontalInput = -1;
        }


        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround && rb.velocity.y >= 0)
        {
            shouldJump = true;
            isOnGround = false;
        }

        transform.Translate(new Vector2(horizontalInput, 0) * moveSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (shouldJump)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            shouldJump = false;
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }

    public void StepOnGround()
    {
        isOnGround = true;
    }

    public void StepOnBooster()
    {
        rb.AddForce(Vector2.up * boosterJumpAmount, ForceMode2D.Impulse);
    }

    public void Respawn()
    {
        transform.position = respawnSpot.transform.position;
    }
}
