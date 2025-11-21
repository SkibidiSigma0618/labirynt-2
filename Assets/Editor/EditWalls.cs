using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.AI;

public class EditWalls : MonoBehaviour
{
    [MenuItem("Tools/Add NavObstacle")]
    static void AddNavmesh()
    {
        foreach(Transform child in GameObject.Find("Walls").transform)
        {
            child.AddComponent<NavMeshObstacle>();
            child.GetComponent<NavMeshObstacle>().carving = true;
        }
    }
}
