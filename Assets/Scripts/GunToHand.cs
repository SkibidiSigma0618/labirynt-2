using UnityEngine;

public class GunToHand : MonoBehaviour

    
{
    public GameObject wrist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        transform.position = wrist.transform.position;
        transform.rotation = Quaternion.LookRotation(forward);
        transform.Rotate(Vector3.left, 90);
        transform.Rotate(Vector3.forward, 90);
        transform.Rotate(Vector3.up, -90);
    }
}
