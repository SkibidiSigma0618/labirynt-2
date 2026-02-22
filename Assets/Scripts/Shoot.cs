using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private InputAction shootAction;
    public Transform firePoint;


    void Awake()
    {
        shootAction = InputSystem.actions.FindAction("Shoot");
        
    }

    private void OnEnable()
    {
        if (shootAction != null)
        {
            shootAction.Enable();
            shootAction.performed += FireOnce;
        }
    }

    private void OnDisable()
    {
        if (shootAction != null)
        {
            shootAction.performed -= FireOnce;
            shootAction.Disable();
        }
    }

    private void FireOnce(InputAction.CallbackContext context)
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, null);
            Destroy(bullet, 0.5f);
        }
    }
}
