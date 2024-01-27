using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class moveTo : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    [SerializeField] private GameObject sandwich;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject toilet;
    [SerializeField] private GameObject center;
    private static float stopDistance = 1f;
    private static float changeTime = 1.0f;
    private float timer = 0.0f;
    private float incrementNeedsTimer = 0.0f;
    [SerializeField] private float maxHunger = 500.0f;
    [SerializeField] private float maxThirst = 500.0f;
    [SerializeField] private float maxWC = 500.0f;
    public float hunger;
    public float thirst;
    public float wc;
    [SerializeField] private static float addValue = 50.0f;
    private bool isNearTarget = false;
    private Destination destination;

    void Start()
    {
        hunger = maxHunger;
        thirst = maxThirst;
        wc = maxWC;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        destination = Destination.Center;
    }

    void Update()
    {
        Debug.Log("Is Near target: " + isNearTarget);

        timer += Time.deltaTime;

        if (timer >= changeTime)
        {
            CheckAndDecreamentNeeds();
            timer = 0.0f;
        }

        if(!isNearTarget)
        {
            if (hunger < 150.0f)
            {
                MoveToTarget(sandwich, Destination.Sandwich);
            }
            else if (thirst < 150.0f)
            {
                MoveToTarget(water, Destination.Water);
            }
            else if (wc < 150.0f)
            {
                MoveToTarget(toilet, Destination.Toilet);
            }
        }
        else {
            switch (destination) 
            {
                case Destination.Sandwich:
                    IncrementNeeds(ref hunger, ref maxHunger);
                    break;
                case Destination.Water:
                    IncrementNeeds(ref thirst, ref maxThirst);
                    break;
                case Destination.Toilet:
                    IncrementNeeds(ref wc, ref maxWC);
                    break;
            }
        }

        CheckNeeds();
    }

    private void CheckAndDecreamentNeeds()
    {
        if(!isNearTarget || destination != Destination.Sandwich)
        {
            hunger -= 5.0f;
        }

        if(!isNearTarget || destination != Destination.Water)
        {
            thirst -= 7.0f;
        }

        if(!isNearTarget || destination != Destination.Toilet)
        {
            wc -= 3.0f;
        }
    }

    private void MoveToTarget(GameObject target, Destination destinationName)
    {
        this.destination = destinationName;
        float distanceToTarget = Vector3.Distance(target.transform.position, _agent.transform.position);

        if (distanceToTarget > stopDistance)
        {
            Debug.Log("Moving to target: " + target.name);
            _agent.SetDestination(target.transform.position);
            isNearTarget = false;
        }
        else if (distanceToTarget <= stopDistance)
        {
            isNearTarget = true;
        }

    }

    private void IncrementNeeds(ref float need, ref float maxNeed)
    {
        incrementNeedsTimer += Time.deltaTime;

        if (incrementNeedsTimer >= changeTime)
        {
            if(need < maxNeed)
            {
                need += addValue;
                //Debug.Log("Need increased: " + need);
            }
            else
            {
                MoveToTarget(center, Destination.Center);
            }
            
            incrementNeedsTimer = 0f;
        }
    }

    private void CheckNeeds()
    {
        if (hunger <= 0.0f || thirst <= 0.0f || wc <= 0.0f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

enum Destination {
    Sandwich,
    Water,
    Toilet,
    Center
}