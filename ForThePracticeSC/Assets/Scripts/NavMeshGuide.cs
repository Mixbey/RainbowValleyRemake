using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGuide : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public NavMeshAgent orco;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }
    void Update()
    {
        agent.SetDestination(target.position);
    }
}