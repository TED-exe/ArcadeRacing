using System;
using System.Collections;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class CarAi : MonoBehaviour
{
    [SerializeField] private WaypointPath CurrSelectedPath;
    private void AiControll()
    {

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
}
