using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, 0, 20);
        transform.Translate(move * Time.deltaTime);
    }
}
