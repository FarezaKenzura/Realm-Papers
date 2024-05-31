using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BezierUtility
{
    public static Vector3 CalculateBezierPoint(float t, Vector3[] points)
    {
        if (points.Length < 2)
        {
            throw new ArgumentException("At least 2 control points are required for Bezier curves.");
        }

        return DeCasteljau(points, t);
    }

    private static Vector3 DeCasteljau(Vector3[] points, float t)
    {
        while (points.Length > 1)
        {
            Vector3[] nextPoints = new Vector3[points.Length - 1];
            for (int i = 0; i < nextPoints.Length; i++)
            {
                nextPoints[i] = Vector3.Lerp(points[i], points[i + 1], t);
            }
            points = nextPoints;
        }
        return points[0];
    }
}
