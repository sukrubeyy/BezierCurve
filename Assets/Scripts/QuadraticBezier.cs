using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class QuadraticBezier : MonoBehaviour
{
    private int _SegmentCount = 50;
    public Vector3[] positions = new Vector3[50];
    public LineRenderer lineRenderer;
    public Transform[] controlPoints;
    void Start()
    {
        if (!lineRenderer)
            lineRenderer = GetComponent<LineRenderer>();
            
        lineRenderer.positionCount=_SegmentCount;
    }

    void Update()
    {
        DrawCurve();
    }

    void DrawCurve()
    {
        for (int i = 1; i <= _SegmentCount; i++)
        {
            float t = i / (float)_SegmentCount;
            positions[i - 1] = CalculateQuadratic(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position);
            lineRenderer.SetPosition(i - 1, positions[i - 1]);
        }
    }

    Vector3 CalculateQuadratic(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        //B(t) = (1-t)*(1-t) * p0 + 2(1-t)*t*p1+ t*t*p2;

        float u = 1 - t;
        float uu = u * u;
        float tt = t * t;

        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);

        return p;
    }
}
