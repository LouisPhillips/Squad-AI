using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    public enum enumState { Idle, Following, Attacking, Position, Retreat, LineUp, FormPosition, PushForward, LeaderAttack };
    public enumState state;
    enumState storageState;

    private float playerDistance;
    public RaycastHit hit;
    public float detectionRange = 10f;
    public int health = 10;

    public Vector3 GoToPos;
    public bool selected;

    private RaycastHit enemyCast;
    public bool canAttack = true;
    private float attackDelay;
    public float attackTime = 2f;

    public bool attacked;
    public float attacked_timer;

    public bool dead = false;
    bool retreating = false;

    private float healDelay = 1f;
    private float healTime;

    public Transform camp;
    Heal heal;
    GameObject[] enemies;
    GameObject leader;

    public Transform player;

    GameObject manager;
    //public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.transform.GetComponent<NavMeshAgent>();
        state = enumState.Idle;
        heal = GetComponent<Heal>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        leader = GameObject.FindGameObjectWithTag("Leader");
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case enumState.Idle:
                {
                    manager.GetComponent<SelectionWheel>().state = SelectionWheel.swState.Normal;
                    agent.destination = transform.position;
                    break;
                }
            case enumState.Following:
                {
                    manager.GetComponent<SelectionWheel>().state = SelectionWheel.swState.Following;
                    agent.destination = player.transform.position;
                    break;
                }
            case enumState.Attacking:
                {
                    manager.GetComponent<SelectionWheel>().state = SelectionWheel.swState.Attacking;
                    float enemydistance = Vector3.Distance(GetClostestEnemy().position, transform.position);
                    if (enemydistance < detectionRange)
                    {
                        agent.destination = GetClostestEnemy().position;
                        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.forward / 3, Color.green);
                        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.forward, out enemyCast, 5))
                        {
                            GetComponent<Animator>().SetBool("Attacking", true);
                            if (enemyCast.transform.tag == "Enemy")
                            {
                                Attack();
                            }
                        }
                    }
                    else if (enemydistance > detectionRange)
                    {
                        state = storageState;
                        GetComponent<Animator>().SetBool("Attacking", false);
                        attacked = false;
                    }


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
                    break;
                }
            case enumState.Position:
                {
                    manager.GetComponent<SelectionWheel>().state = SelectionWheel.swState.Normal;
                    agent.destination = GoToPos;

                    break;
                }
            case enumState.Retreat:
                {
                    manager.GetComponent<SelectionWheel>().state = SelectionWheel.swState.Retreating;
                    agent.destination = camp.transform.position;
                    retreating = true;
                    
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            healTime += Time.deltaTime;
                            if (healDelay < healTime)
                            {
                                health += 10;
                                healTime = 0;
                            }
                        }
                    }

                    if (health >= 100)
                    {
                        health = 100;
                        retreating = false;
                        state = enumState.LineUp;
                    }
                    break;
                }

            case enumState.LineUp:
                {
                    manager.GetComponent<SelectionWheel>().state = SelectionWheel.swState.Following;
                    agent.destination = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
                    break;
                }

            case enumState.FormPosition:
                {

                    break;
                }
            case enumState.PushForward:
                {
                    manager.GetComponent<SelectionWheel>().state = SelectionWheel.swState.Following;
                    /*float distance;
                    distance = Vector3.Distance(transform.position, leader.transform.position);
                    if (distance < 15)
                    {
                        state = enumState.LeaderAttack;
                    }
                    else
                    {
                        agent.destination = new Vector3(transform.position.x, transform.position.y, leader.transform.position.z);
                    }*/
                    state = enumState.LeaderAttack;
                    break;
                }
            case enumState.LeaderAttack:
                {
                    manager.GetComponent<SelectionWheel>().state = SelectionWheel.swState.Attacking;
                    RaycastHit leaderCast;
                    agent.destination = leader.transform.position;
                    if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.forward, out leaderCast, 5))
                    {
                        GetComponent<Animator>().SetBool("Attacking", true);
                        if (leaderCast.transform.gameObject.tag == "Leader")
                        {
                            LeaderAttack();
                        }
                    }

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
                    break;
                }
        }
        Debug.DrawLine(transform.position, GetClostestEnemy().position,Color.red);
        Transform child = transform.Find("Selected");
        if (selected)
        {


            child.gameObject.SetActive(true);

        }
        else
        {
            child.gameObject.SetActive(false);
        }

        if (health <= 0)
        {
            transform.gameObject.SetActive(false);
            dead = true;
        }

        if (health <= 30 && !dead)
        {
            state = enumState.Retreat;
        }

        if (attacked && health > 30 && !retreating)
        {
            state = enumState.Attacking;
        }

        if(!attacked)
        {
            storageState = state;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, detectionRange);
    }

    Vector3 RandomSphere(Vector3 start, float range)
    {
        Vector3 randomPoint = Random.insideUnitSphere * range;

        randomPoint += start;

        NavMeshHit navMeshHit;

        NavMesh.SamplePosition(randomPoint, out navMeshHit, range, NavMesh.AllAreas);

        return navMeshHit.position;
    }

    void Attack()
    {
        if (canAttack)
        {
            GetClostestEnemy().GetComponent<Enemy>().health -= 1;
        }
        canAttack = false;

    }

    void LeaderAttack()
    {
        if (canAttack)
        {

            leader.GetComponent<Leader>().leaderHealth -= 1;
        }
        canAttack = false;

    }

    public Transform GetClostestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        Transform trns = null;

        foreach (GameObject enemy in enemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (currentDistance < closestDistance && !enemy.GetComponent<Enemy>().dead)
            {
                closestDistance = currentDistance;
                trns = enemy.transform;
            }
        }
        return trns;
    }
}
