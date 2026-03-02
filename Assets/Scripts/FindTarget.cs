using System.Linq;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    MoveAI moveAI;
    void Start()
    {
        if (CompareTag("Enemy"))
        {
            moveAI = GetComponent<MoveAI>();
            moveAI.target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else if (CompareTag("Bullet"))
        {
            GetComponent<Respawn>().respawn = GameObject.Find("Respawn").transform;
        }
        
        
    }
}
