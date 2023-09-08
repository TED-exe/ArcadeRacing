using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    public List<Transform> wayPoints;
    [SerializeField] private Color lineColor;

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        wayPoints = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != transform)
            {
                wayPoints.Add(pathTransform[i]);
            }
        }

        for (int i = 0; i < wayPoints.Count; i++)
        {
            Vector3 currWayPoint = wayPoints[i].position;
            Vector3 prevWayPoint = Vector3.zero;
            if (i > 0)
                prevWayPoint = wayPoints[i - 1].position;
            else if( i == 0 && wayPoints.Count >1)
                prevWayPoint = wayPoints[wayPoints.Count - 1].position;

            Gizmos.DrawLine(currWayPoint, prevWayPoint);
            Gizmos.DrawSphere(currWayPoint, 0.2f);
        }
    }
}
