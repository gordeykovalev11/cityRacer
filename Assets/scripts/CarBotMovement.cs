using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBotMovement : MonoBehaviour
{

    public List<Transform> botPoints;
    public float botSpeed = 12.5f;
    private int botPointIndex = 0;
    public float turnSpeed = 6f;

    void Update()
    {
        MoveToPoint();
        TurnToPoint();
    }
    void MoveToPoint()
    {
        if (botPointIndex < botPoints.Count)
        {
            Transform target = botPoints[botPointIndex];
            Vector3 movement = Vector3.MoveTowards(transform.position, target.position, botSpeed * Time.deltaTime);
            transform.position = movement;
            if (transform.position == target.position)
            {
                botPointIndex++;
                if (botPointIndex == botPoints.Count)
                {
                    botPointIndex = 0;
                }
            }
        }
    }
    void TurnToPoint ()
    {
        if (botPointIndex < botPoints.Count)
        {
            Vector3 directionToTarget = botPoints[botPointIndex].position-transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,turnSpeed * Time.deltaTime);
        }
    }
}
