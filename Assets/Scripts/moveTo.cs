using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class moveTo : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject center;
    public float stopDistance = 1f;
    public int counter = 0;
    public float changeTime = 1.0f;
    public float hungerChangeValue = 1.0f;
    public float thirstChangeValue = 1.0f;
    public float wcChangeValue = 1.0f;
    private float timer = 0.0f;
    public float maxHunger = 500.0f;
    public float maxThirst = 500.0f;
    public float maxWC = 500.0f;
    public float hunger = 500.0f;
    public float thirst = 500.0f;
    public float wc = 500.0f;

    public float addValue = 50.0f;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        //_animator = GetComponent<Animator>();
        //target = targets[0];
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= changeTime)
        {
            hunger -= hungerChangeValue;
            thirst -= thirstChangeValue;
            wc -= wcChangeValue;
            timer = 0.0f;
        }

        if (hunger < 100.0f)
        {
            MoveToTarget(target1, ref hunger, maxHunger);
        }
        else if (thirst < 100.0f)
        {
            MoveToTarget(target2, ref thirst, maxThirst);
        }
        else if (wc < 100.0f)
        {
            MoveToTarget(target3, ref wc, maxWC);
        }
        else
        { 
            _agent.SetDestination(center.transform.position);
        }

        CheckNeeds();

    }

    public void IncrementNeeds(ref float need, ref float maxNeed)
    {
        if (need < maxNeed)
        {
            timer += Time.deltaTime;

            while (timer >= changeTime)
            {
                need += addValue;
                timer -= changeTime;
                Debug.Log("Need increased: " + need);
            }
        }
    }

    public void MoveToTarget(GameObject destination, ref float need, float maxNeed)
    {
        float distanceToTarget = Vector3.Distance(destination.transform.position, _agent.transform.position);

        if (distanceToTarget > stopDistance)
        {
            Debug.Log("Moving to target: " + destination.name);
            _agent.SetDestination(destination.transform.position);
            _agent.isStopped = false;
            //_animator.SetBool("isWalking", true);
        }
        else
        {
            Debug.Log("Arrived at target: " + destination.name);
            _agent.isStopped = true;

            if (destination != center && need >= maxNeed)
            {
                need = maxNeed;
                _agent.isStopped = false;
                _agent.SetDestination(center.transform.position);
                Debug.Log("Returning to center");
            }
        }

    }



    public void CheckNeeds()
    {
        if (hunger <= 0.0f || thirst <= 0.0f || wc <= 0.0f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
