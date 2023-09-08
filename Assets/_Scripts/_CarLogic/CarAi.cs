using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAi : MonoBehaviour
{
    [Header("REFERENCE")]
    [SerializeField] private Transform mouseIndicator;
    [SerializeField] private DrawPath path;
    private CarPhysics carPhysics;
    [Header("SETTING")]
    [SerializeField, Range(0.1f, 10f)] private float waypointRadius;
    [SerializeField] private bool usePath = true;
    private int currWayPoint = 0;
    private Vector3 targetPosition;

    private void Awake()
    {
        carPhysics = GetComponent<CarPhysics>();
    }
    private void FixedUpdate()
    {
        float turnAmount = AiSteering();
        float acceleration =AiDrive();
        
        if(usePath)
            targetPosition = CheckWayPointDistance();
        else
            targetPosition = mouseIndicator.position;

        carPhysics.GetInput(turnAmount, acceleration);
    }
    private Vector3 CheckWayPointDistance()
    {
        if (Vector3.Distance(transform.position, path.wayPoints[currWayPoint].position) < waypointRadius)
        {
            if (currWayPoint == path.wayPoints.Count - 1)
                currWayPoint = 0;
            else
                currWayPoint++;
        }
        return path.wayPoints[currWayPoint].position;
    }
    private float AiDrive()
    {
        return 1;
    }

    private float AiSteering()
    {
        Vector3 dirToTargetPosition = (targetPosition - transform.position).normalized;
        float angleToDir = Vector3.SignedAngle(transform.forward, dirToTargetPosition, Vector3.up);

        Debug.Log(angleToDir);
        //if (angleToDir > 0)
        //    turnAmount = angleToDir;
        //else
        //    turnAmount = -angleToDir;

        return angleToDir /180f;
    }




    /*private void AiControll()
    {
        float accelerationAmount;
        float turnAmount;

        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        Vector3 dirToTargetPosition = (targetPosition - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dirToTargetPosition);

        float angleToDir = Vector3.SignedAngle(transform.forward, dirToTargetPosition,Vector3.up);

        if (dot > 0)
            accelerationAmount = 1;
        else
        {
            float reverseDistance = 15f;
            if (distanceToTarget > reverseDistance)
                accelerationAmount = 1;
            else
                accelerationAmount = -1;
        }


        if (angleToDir > 0)
            turnAmount = 1;

        else
            turnAmount = -1;

        carPhysics.GetInput(turnAmount, accelerationAmount);

        /*setTargetPosition(path.wayPoints[currWayPoint].position);
        Debug.Log(path.wayPoints[currWayPoint].position);

        float acceleration;
        float turnAmount;

        float reachedTargetDistance = 2f;
        float distToTarget = Vector3.Distance(transform.position, targetPosition);


        Vector3 dirToTargetPosition = (targetPosition - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dirToTargetPosition);
        float angleToDir = Vector3.SignedAngle(transform.forward, dirToTargetPosition, Vector3.up);

        if (dot > 0)
            acceleration = 1;
        else
        {
            float reverseDistance = 15f;
            if (distToTarget > reverseDistance)
                acceleration = 1;
            else
                acceleration = -1;
        }


        if (angleToDir > 0)
            turnAmount = 1;

        else
            turnAmount = -1;

        carPhysics.GetInput(turnAmount, acceleration);
    }*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(path.wayPoints[currWayPoint].position, waypointRadius);
    }
}
