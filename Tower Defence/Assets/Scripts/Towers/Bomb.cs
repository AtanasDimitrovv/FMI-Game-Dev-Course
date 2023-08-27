using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform pivot;
    public Transform model;

    public float moveSpeed;

    [HideInInspector]
    public Vector3 targetPoint;

    public GameObject explodeEffect;

    public float damage;
    public LayerMask enemyMask;

    public float explodeRange;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosition = transform.position;

        Vector3 centerPosition = (transform.position + targetPoint) * 0.5f;
        transform.position = centerPosition;

        transform.right = targetPoint - transform.position;

        model.transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        pivot.localRotation = Quaternion.RotateTowards(pivot.localRotation, Quaternion.Euler(0f, 0f, 180f), moveSpeed * Time.deltaTime);
        model.rotation = Quaternion.identity;

        if (Vector3.Distance(model.position, targetPoint) < 0.1f)
        {
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, explodeRange, enemyMask);

            foreach (Collider col in collidersInRange)
            {
                col.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            if (explodeEffect != null)
            {
                Instantiate(explodeEffect, model.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
