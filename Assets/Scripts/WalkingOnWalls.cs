using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WalkingOnWalls : MonoBehaviour
{

    public float gravity = 9.81f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => rb = GetComponent<Rigidbody>();

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, 2.0f))
        {
            Vector3 gravityDir = -hit.normal;
            rb.AddForce(gravityDir * gravity, ForceMode.Acceleration);

            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            
        }
    }
}
