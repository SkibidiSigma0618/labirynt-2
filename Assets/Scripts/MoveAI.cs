using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    void Update()
    {
        agent.SetDestination(target.position);
    }
}