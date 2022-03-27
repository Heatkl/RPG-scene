using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentCube : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 finishPosition;
    private NavMeshAgent navMeshAgent;
    private Vector3 currentPosition;
    public Transform player;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentPosition = startPosition;
        navMeshAgent.SetDestination(currentPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
        if(Vector3.Distance(transform.position, currentPosition) > 1f) return;
        if (currentPosition == startPosition)
            currentPosition = finishPosition;
        else currentPosition = startPosition;
        navMeshAgent.SetDestination(currentPosition);
    }
}
