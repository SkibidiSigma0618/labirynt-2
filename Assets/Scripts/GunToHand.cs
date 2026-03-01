using UnityEngine;

public class GunToHand : MonoBehaviour

    
{
    public Transform wrist, aimPoint;
    public Vector3 rotationOffset;
    
    void LateUpdate()
    {
        transform.position = wrist.position;
        Vector3 targetDirection = aimPoint.position - transform.position;


        if (targetDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(targetDirection) * Quaternion.Euler(rotationOffset);
        }
    }
}
