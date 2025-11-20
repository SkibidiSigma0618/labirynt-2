using UnityEngine;
using UnityEditor;

public class WallGenerator : MonoBehaviour
{
    [MenuItem("Tools/Generate Walls")]
    static void GenerateWalls()
    {
        int rows = 20;    
        int cols = 20;    
        float spacingX = 1.2f; // slightly more than 1 to avoid overlap
        float spacingZ = 5.2f; // slightly more than 5 to avoid overlap

        GameObject parent = new GameObject("Walls");
        parent.tag = "Walls";

        // vertical walls (columns)
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= cols; j++)
            {
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.name = $"column {i},{j}";
                wall.transform.parent = parent.transform;

                // scale and position
                wall.transform.localScale = new Vector3(1f, 5f, 5f);
                wall.transform.position = new Vector3(j * spacingX, 2.5f, i * spacingZ);
                wall.SetActive(false);
            }
        }

        // horizontal walls (rows)
        for (int i = 0; i <= rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.name = $"row {i},{j}";
                wall.transform.parent = parent.transform;

                // scale and position
                wall.transform.localScale = new Vector3(1f, 5f, 5f);
                wall.transform.position = new Vector3(j * spacingX, 2.5f, i * spacingZ);
                wall.SetActive(false);
            }
        }

        Debug.Log("Walls generated and disabled!");
    }
}