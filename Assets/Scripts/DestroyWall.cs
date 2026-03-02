using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject destroyedPrefab;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            GameObject obj = Instantiate(destroyedPrefab, transform.position, transform.rotation, null);
            obj.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            Destroy(this.gameObject);
            Destroy(obj, 4f);
        }
    }
}
