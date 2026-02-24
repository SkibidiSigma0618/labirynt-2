using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject death;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            death.SetActive(true);
        }
    }
}
