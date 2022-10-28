using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patrol : MonoBehaviour
{
    
    [SerializeField] private Transform [] moveLocations;
    private float waitTime;
    public float startWaitTime;
    private int randomSpot;

    private NavMeshAgent navMeshAgent;

    public Animator anim;


    private void Awake()
    {   
        anim = GetComponent<Animator>();
        randomSpot = Random.Range(0, moveLocations.Length);


        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        navMeshAgent.destination = moveLocations[randomSpot].position;
        anim.SetBool("walking",true);
        anim.SetBool("idle", false);

        if(navMeshAgent.remainingDistance < 2f)
        {
            anim.SetBool("walking",false);
            anim.SetBool("idle", true);
            if(waitTime <=0)
            {
                randomSpot = Random.Range(0, moveLocations.Length);   
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
