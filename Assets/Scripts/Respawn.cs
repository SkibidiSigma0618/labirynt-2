using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawn;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().Teleport(respawn);
        }
    }
}
