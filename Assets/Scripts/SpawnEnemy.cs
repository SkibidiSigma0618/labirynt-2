using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject deathScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Spawn", 5, 3.0f);
    }

    void Spawn()
    {
        Vector3 spawn = GetRandomPoint(new Vector3(50, 0, 50), 30.0f);
        GameObject enemy = Instantiate(enemyPrefab, spawn, enemyPrefab.transform.rotation, null);
        Death death = enemy.GetComponent<Death>();
        death.death = deathScreen;
    }

    Vector3 GetRandomPoint(Vector3 center, float radius)
    {
        for (int i = 0; i < 30; i++) 
        {
            Vector3 randomPos = center + Random.insideUnitSphere * radius;

            if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }

        return center;
    }


}
