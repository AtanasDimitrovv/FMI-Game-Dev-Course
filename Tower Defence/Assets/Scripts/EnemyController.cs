using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]
    public float speedModifier = 1f;

    private Path mainPath;
    private int currPoint;
    private bool reachedEnd;

    public float timeBetweenAttacks;
    public float damagePerAttack;

    private float attackCounter;

    private Castle castle;

    private int selectedAttackPoint;

    public bool isFlying;
    public float flyHeight;

    [HideInInspector]
    public bool isSlowed = false;

    // Start is called before the first frame update
    void Start()
    {
        if (mainPath == null)
        {
            mainPath = FindObjectOfType<Path>();
        }

        if (castle == null)
        {
            castle = FindObjectOfType<Castle>();
        }

        attackCounter = timeBetweenAttacks;

        if (isFlying)
        {
            transform.position += Vector3.up * flyHeight;
            currPoint = mainPath.points.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.levelIsActive)
        {
            if (!reachedEnd)
            {
                transform.LookAt(mainPath.points[currPoint]);

                if (!isFlying)
                {
                    transform.position = Vector3.MoveTowards(transform.position, mainPath.points[currPoint].position, moveSpeed * Time.deltaTime * speedModifier);

                    if (Vector3.Distance(transform.position, mainPath.points[currPoint].position) < 0.01f)
                    {
                        currPoint++;
                        if (currPoint >= mainPath.points.Length)
                        {
                            reachedEnd = true;

                            selectedAttackPoint = Random.Range(0, castle.attackPoints.Length);
                        }
                    }
                } else
                {
                    transform.position = Vector3.MoveTowards(transform.position, mainPath.points[currPoint].position + (Vector3.up * flyHeight), moveSpeed * Time.deltaTime * speedModifier);

                    if (Vector3.Distance(transform.position, mainPath.points[currPoint].position + (Vector3.up * flyHeight)) < 0.01f)
                    {
                        currPoint++;
                        if (currPoint >= mainPath.points.Length)
                        {
                            reachedEnd = true;

                            selectedAttackPoint = Random.Range(0, castle.attackPoints.Length);
                        }
                    }
                }
            }
            else
            {
                if (!isFlying)
                {
                    transform.position = Vector3.MoveTowards(transform.position, castle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime * speedModifier);
                } else
                {
                    transform.position = Vector3.MoveTowards(transform.position, castle.attackPoints[selectedAttackPoint].position + (Vector3.up * flyHeight), moveSpeed * Time.deltaTime * speedModifier);
                }

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    attackCounter = timeBetweenAttacks;

                    castle.TakeDamage(damagePerAttack);
                }
            }
        }

        if (!isSlowed)
        {
            speedModifier = 1f;
        }

        isSlowed = false;
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        castle = newCastle;
        mainPath = newPath;
    }
}
