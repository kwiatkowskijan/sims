using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTo : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    public GameObject target;
    public List<GameObject> targets;
    public float stopDistance = 1f;
    public int counter = 0;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        target = targets[0];
    }

    void Update()
    {
        


        if(Vector3.Distance(target.transform.position, _agent.transform.position) > stopDistance) 
        {
            _agent.SetDestination(target.transform.position);
            _agent.isStopped = false;
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _agent.isStopped = true;
            _animator.SetBool("isWalking", false);
            counter++;
            if(counter >= targets.Count) 
            { 
                counter = 0;
            }
            target = targets[counter];
        }

    }
}
