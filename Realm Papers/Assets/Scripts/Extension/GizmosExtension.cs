using UnityEngine;

public static class GizmosExtension
{
    public static void DrawWireCircle(Vector3 position, float radius, int segments = 100)
    {
        float angle = 2f * Mathf.PI / segments;
        Vector3[] points = new Vector3[segments + 1];

        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Cos(i * angle) * radius;
            float y = Mathf.Sin(i * angle) * radius;
            points[i] = new Vector3(x, y) + position;
        }

        for (int i = 0; i < segments; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
    }
}