using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LinearBezier : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private int _SegmentCount = 50;
    public Vector3[] _positions = new Vector3[50];
    public Transform[] points;

    void Start()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.positionCount = _SegmentCount;
    }
    void Update()
    {
        DrawLinearCurve();
    }

    private void DrawLinearCurve()
    {
        for (int i = 1; i < _SegmentCount + 1; i++)
        {
            float t = i / (float)_SegmentCount;
            _positions[i - 1] = CalculateLinearBezier(t, points[0].position, points[1].position);
            lineRenderer.SetPosition(i - 1, _positions[i - 1]);
        }
    }

    Vector3 CalculateLinearBezier(float t, Vector3 p0, Vector3 p1)
    {
        float tValue = t;
        Vector3 p = p0 + t * (p1 - p0);
        return p;
    }

}
