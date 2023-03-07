using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update

    Transform target;
    [SerializeField] float chaseRange = 5f;
    public float turnSpeed = 5f;

    NavMeshAgent agent;
    bool provoked = false;
    float distancetotarget = Mathf.Infinity;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
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
        FaceTarget();
        if (distancetotarget <= agent.stoppingDistance)
        {
            AttackPlay();
        }
        if (distancetotarget >=agent.stoppingDistance)
        {
            chasePlayer();
        }
    }
    public void OnDamageTaken()
    {
        provoked = true;
    }
    void chasePlayer()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        agent.SetDestination(target.position);
    }
    private void AttackPlay()
    {
        GetComponent<Animator>().SetBool("attack", true);
      
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
