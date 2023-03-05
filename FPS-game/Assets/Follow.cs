using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent agent;
    bool provoked = false;
    float distancetotarget = Mathf.Infinity;
    void Start()
    {
     agent = GetComponent<NavMeshAgent>();   
    }

     void Update()
    {
        distancetotarget = Vector3.Distance(target.position,transform.position);
        if(provoked)
        {
            ENGAGE();
        }
        else if(distancetotarget <= chaseRange) {
            provoked = true;
        }
       
        
    }
    void ENGAGE()
    {
        if (distancetotarget <= agent.stoppingDistance)
        {
            AttackPlay();
        }
        if (distancetotarget >=agent.stoppingDistance)
        {
            chasePlayer();
        }
    }
    void chasePlayer()
    {
        agent.SetDestination(target.position);
    }
    private void AttackPlay()
    {
        Debug.Log("Attacking");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
