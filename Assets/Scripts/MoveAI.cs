using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public Animator anim;

    void Update()
    {
        agent.SetDestination(target.position);
    }
}