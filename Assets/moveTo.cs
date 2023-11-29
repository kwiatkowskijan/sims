using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class moveTo : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    public GameObject target;
    public List<GameObject> targets;
    public float stopDistance = 1f;
    public int counter = 0;

    public float changeTime = 1.0f;
    public float hungerChangeValue = 1.0f;
    public float thirstChangeValue = 1.0f;
    public float wcChangeValue = 1.0f;
    private float timer = 0.0f;

    public float hunger = 500.0f;
    public float thirst = 500.0f;
    public float wc = 500.0f;


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

        timer += Time.deltaTime;

        if (timer >= changeTime)
        {
            hunger -= hungerChangeValue;
            thirst -= thirstChangeValue;
            wc -= wcChangeValue;
            timer = 0.0f;
        }


        if(hunger == 0.0f || thirst == 0.0f || wc == 0.0f)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
