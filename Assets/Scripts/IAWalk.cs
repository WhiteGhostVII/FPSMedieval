using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public GameObject target;
    public Animator anim;
    public Vector3 patrolposition;
    public float stoppedTime;
    public static IAWalk Instance;

    public enum IaState
    {
        Stopped,
        Berserk,
        Attack,
        Damage,
        Dying,
        Patrol,
    }
    public IaState currentState;
    void Start()
    {
        Instance = this;
        patrolposition = new Vector3(transform.position.x + Random.Range(-10, 10),
                                    transform.position.y,
                                    transform.position.z + Random.Range(-10, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (currentState)
        {
            case IaState.Stopped:
                Stopped();
                break;
            case IaState.Berserk:
                Berserk();
                break;
            case IaState.Attack:
                Attack();
                break;
            case IaState.Damage:
                Damage();
                break;
            case IaState.Dying:
                Dying();
                break;
            case IaState.Patrol:
                Patrol();
                break;

        }
        
        anim.SetFloat("Velocity", agent.velocity.magnitude);
    }

    void Patrol()
    {
        agent.isStopped = false;
        agent.SetDestination(patrolposition);
        anim.SetBool("Attack", false);
        if (agent.velocity.magnitude < 0.1f)
        {
            stoppedTime += Time.deltaTime;
        }
        if(stoppedTime>3)
        {
            stoppedTime = 0;
            patrolposition = new Vector3(transform.position.x + Random.Range(-10, 10),
                                     transform.position.y,
                                     transform.position.z + Random.Range(-10, 10));
        }
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 6)
            {
                currentState = IaState.Berserk;
            }
        }

    }
    void Stopped()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 5)
            {
                currentState = IaState.Patrol;
            }
            if (Vector3.Distance(transform.position, target.transform.position) < 3)
            {
                currentState = IaState.Attack;
            }
        }
    }
    void Berserk()
    {
        agent.isStopped = false;
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
            anim.SetBool("Attack", false);
            if (Vector3.Distance(transform.position, target.transform.position) < 3)
            {
                currentState = IaState.Attack;
            }
            if (Vector3.Distance(transform.position, target.transform.position) > 12)
            {
                currentState = IaState.Patrol;
            }
        }
    }
    void Attack()
    {        
        agent.isStopped = true;
        anim.SetBool("Attack", true);
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 3)
            {
                currentState = IaState.Berserk;
            }
        }
    }
    void Damage()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetTrigger("Hit");
        currentState = IaState.Stopped;
    }
    void Dying()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetBool("Die", true);
    }
}
