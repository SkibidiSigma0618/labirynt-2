using System.Linq;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    MoveAI moveAI;
    void Start()
    {
        moveAI = GetComponent<MoveAI>();
        moveAI.target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
}
