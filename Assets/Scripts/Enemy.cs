using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health;
    private NavMeshAgent agent;
    public enum enumState {Idle,  Wander, Attack, Retreat, Section1, Section2, Section3 };
    public enumState state;

    private float aiDistance;
    private float playerDistance;
    public float detectionRange = 8f;

    private RaycastHit playerCast;

    private bool canAttack = true;
    private float attackDelay;
    public float attackTime = 2f;

    private float wanderDelay;
    public float wanderRange = 10f;
    public float wanderEvery = 7f;
    GameObject[] ais;
    GameObject[] enemies;
    GameObject leader;
    GameObject player;

    GameObject p1;
    GameObject p2;

    public bool dead = false;

    float distance;

    public bool gettingAttacked;

    void Start()
    {
        health = 10;

        agent = gameObject.transform.GetComponent<NavMeshAgent>();

        ais = GameObject.FindGameObjectsWithTag("AI");

        leader = GameObject.FindGameObjectWithTag("Leader");

        p1 = GameObject.FindGameObjectWithTag("Point1");
        p2 = GameObject.FindGameObjectWithTag("Point2");

        player = GameObject.FindGameObjectWithTag("Player");

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        distance = Vector3.Distance(p1.transform.position, p2.transform.position);
        


    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(transform.position, GetClostestAI().position);
        aiDistance = Vector3.Distance(GetClostestAI().position, transform.position);
        playerDistance = Vector3.Distance(player.transform.position, transform.position);
        switch (state)
        {
            case enumState.Idle:
                {
                    wanderDelay += Time.deltaTime;
                    if (wanderDelay > wanderEvery)
                    {
                        state = enumState.Wander;
                        wanderDelay = 0;
                    }

                    if (aiDistance <= detectionRange)
                    {
                        state = enumState.Attack;
                    }
                    break;
                }
            case enumState.Attack:
                {
                    /*if (detectionRange > aiDistance)
                    {
                        agent.destination = ai.transform.position;
                    }

                    else if (detectionRange > playerDistance)
                    {
                        agent.destination = player.transform.position;
                    }*/
                    agent.destination = GetClostestAI().position;
                    if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.forward, out playerCast, 3))
                    {
                        Attack();
                    }

                    if(aiDistance > detectionRange)
                    {
                        state = enumState.Wander;
                    }

                    /*if (aiDistance > detectionRange | playerDistance > detectionRange)
                    {
                        state = enumState.Wander;
                    }*/
                    break;
                }
            case enumState.Wander:
                {
                    agent.SetDestination(RandomSphere(gameObject.transform.position, wanderRange));
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            state = enumState.Idle;
                        }
                    }
                    if (aiDistance <= detectionRange)
                    {
                        state = enumState.Attack;
                    }
                    break;
                }
            case enumState.Retreat:
                {
                    agent.destination = new Vector3(transform.position.x, transform.position.y, leader.transform.position.z);
                    break;
                }
            case enumState.Section1:
                {
                    agent.destination = new Vector3(transform.position.x, transform.position.y, distance / 10);
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            state = enumState.Wander;
                        }
                    }
                    break;
                }
            case enumState.Section2:
                {
                    agent.destination = new Vector3(transform.position.x, transform.position.y, distance / 4);
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            state = enumState.Wander;
                        }
                    }
                    break;
                }
            case enumState.Section3:
                {
                    agent.destination = new Vector3(transform.position.x, transform.position.y, distance / 2);
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            state = enumState.Wander;
                        }
                    }
                    break;
                }
        }

       
        /*if (playerDistance <= detectionRange)
        {
            state = enumState.Attack;
        }
        else
        {
            state = enumState.Wander;
        }*/

        if (!canAttack)
        {
            attackDelay += Time.deltaTime;
            if (attackDelay < attackTime)
            {
                canAttack = false;
            }
            else
            {
                canAttack = true;
                attackDelay = 0f;
            }

        }

        /*playerDistance = Vector3.Distance(ai.transform.position, transform.position);

        if (playerDistance > detectionRange)
        {
            wanderDelay += Time.deltaTime;
            if (wanderDelay > wanderEvery)
            {
                agent.SetDestination(RandomSphere(gameObject.transform.position, wanderRange));
                if (agent.pathStatus == NavMeshPathStatus.PathComplete)
                {
                    wanderDelay = 0;
                }
            }
        }
        if (ai.GetComponent<AI>().health > 0)
        {
            if (playerDistance <= detectionRange)
            {
                agent.destination = ai.transform.position;
            }
        }

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.forward, out playerCast, 3))
        {
            if (playerCast.transform.gameObject.tag == "Player")
            {
                Attack();
            }
            if (playerCast.transform.gameObject.tag == "AI")
            {
                Attack();
            }
        }*/

        /*if (!canAttack)
        {
            attackDelay += Time.deltaTime;
            if (attackDelay < attackTime)
            {
                canAttack = false;
            }
            else
            {
                canAttack = true;
                attackDelay = 0f;
            }

        }*/


        if (health <= 0)
        {
            transform.gameObject.SetActive(false);
            dead = true;
            /* leader = leader.GetComponent<Leader>();
             leader.totalEnemy -= 1;*/
        }
    }
    void Attack()
    {
        if (GetClostestAI().tag == "AI")
        {
            if (canAttack)
            {
                GetClostestAI().GetComponent<AI>().health -= 5;
                GetClostestAI().GetComponent<AI>().attacked = true;
            }
            canAttack = false;
        }
        /*if (playerCast.transform.tag == "AI")
        {
            foreach (GameObject ai in ais)
            {
                if (canAttack)
                {
                    ai.GetComponent<AI>().health -= 1;
                }
                canAttack = false;
            }
        }
        else if (playerCast.transform.tag == "Player")
        {
            if (canAttack)
            {
                player.GetComponent<PlayerMovement>().health -= 1;
            }
            canAttack = false;
        }*/
    }

    Vector3 RandomSphere(Vector3 start, float range)
    {
        Vector3 randomPoint = Random.insideUnitSphere * range;

        randomPoint += start;

        NavMeshHit navMeshHit;

        NavMesh.SamplePosition(randomPoint, out navMeshHit, range, NavMesh.AllAreas);

        return navMeshHit.position;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, detectionRange);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            agent.destination = other.transform.position; 
            state = enumState.Attack;
        }
    }*/
    public Transform GetClostestAI()
    {
        float closestDistance = Mathf.Infinity;
        Transform trns = null;

        foreach (GameObject ai in ais)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, ai.transform.position);
            if(currentDistance < closestDistance && !ai.GetComponent<AI>().dead)
            {
                closestDistance = currentDistance;
                trns = ai.transform;
            }
        }
        return trns; 
    }
}
