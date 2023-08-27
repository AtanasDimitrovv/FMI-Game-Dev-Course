using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;

    public GameObject impactEffect;

    public float damageAmount;

    private bool hasDamaged;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !hasDamaged)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            hasDamaged = true;
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
