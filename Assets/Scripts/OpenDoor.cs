using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    private bool isOpen = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            if (!isOpen)
            {
                StartCoroutine(Open());
            }
            
        }
    }

    IEnumerator Open()
    {
        isOpen = true;

        Quaternion startRotation = door.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(90, 0, 0);
        
        float elapsed = 0f;
        float duration = 3f;


        while (elapsed < duration)
        {   

            door.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
            transform.Rotate(Vector3.forward, 1);
            elapsed += Time.deltaTime;

            yield return null;
        }
        
    }
}
