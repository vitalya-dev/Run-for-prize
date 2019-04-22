using System.Collections;
using UnityEngine;


public class Level : MonoBehaviour
{
    public int cols;
    public int rows;


    private void OnDrawGizmos()
    {
        DrawGizmos(new Vector3(-0.5f * cols, -0.5f * rows, 0));
    }

    private void DrawGizmos(Vector3 origin)
    {
        Matrix4x4 old_matrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawLine(origin, origin + new Vector3(cols, 0, 0));
        Gizmos.DrawLine(origin + new Vector3(0, rows, 0), origin + new Vector3(cols, rows, 0));
        Gizmos.DrawLine(origin, origin + new Vector3(0, rows, 0));
        Gizmos.DrawLine(origin + new Vector3(cols, 0, 0), origin + new Vector3(cols, rows, 0));

        for (int i = 1; i < cols; i++)
        {
            Gizmos.DrawLine(origin + new Vector3(i, 0, 0), origin + new Vector3(i, rows, 0));
        }
        for (int j = 1; j < rows; j++)
        {
            Gizmos.DrawLine(origin + new Vector3(0, j, 0), origin + new Vector3(cols, j, 0));
        }

        Gizmos.matrix = old_matrix;
    }

}