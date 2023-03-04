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
    float distancetotarget = Mathf.Infinity;
    void Start()
    {
     agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        distancetotarget = Vector3.Distance(target.position,transform.position);
        if(distancetotarget <= chaseRange)
        {
               agent.SetDestination(target.position);   
        }
        
    }
}
