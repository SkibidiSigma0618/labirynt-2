using UnityEngine;

public class ShootTurretEdition : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float delay = 0.8f;

    void Start()
    {
        InvokeRepeating("FireOnce", 0, delay);
    }

    private void FireOnce()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 0), null);
            bullet.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            Destroy(bullet, 1f);
        }
    }
}
