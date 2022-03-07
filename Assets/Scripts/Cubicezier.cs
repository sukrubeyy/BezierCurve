using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Cubicezier : MonoBehaviour
{

    public Transform[] controlPoints;
    public LineRenderer lineRenderer;
    private int curveCount = 0;
    private int SEGMENT_COUNT = 50;
    void Start()
    {
        if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        lineRenderer.positionCount = SEGMENT_COUNT;
        curveCount = (int)controlPoints.Length / 3;

    }
    void Update()
    {
        DrawCurve();
    }

    void DrawCurve()
    {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                Vector3 _pos = CalculateCubicBezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, controlPoints[3].position);
                lineRenderer.SetPosition(i - 1, _pos);
            }
    }

    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tSquare = t * t;
        float uSquare = u * u;
        float uCub = uSquare * u;
        float tCub = tSquare * t;

        Vector3 p = uCub * p0;
        p += 3 * uSquare * t * p1;
        p += 3 * u * tSquare * p2;
        p += tCub * p3;

        return p;
    }

}
