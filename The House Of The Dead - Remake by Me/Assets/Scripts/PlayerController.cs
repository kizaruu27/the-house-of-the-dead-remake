using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] waypoints;
    public float turnSpeed = 20f;

    int waypointsIndex;
    float distance;

    void Start() 
    {
        waypointsIndex = 0;
        transform.LookAt(waypoints[waypointsIndex].position);

        Vector3 rotate = waypoints[waypointsIndex].position - transform.position;
        Quaternion lockRotation = Quaternion.LookRotation(rotate);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lockRotation, 10 * Time.deltaTime).eulerAngles;
        transform.localRotation = Quaternion.Euler(0, rotation.y, 0);

    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointsIndex].position);

        if (distance < 2)
        {
            speed = 0;

        }

        if (distance < 1f)
        {
            IncreaseIndex();
        }
        Patrol();

    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].position, speed * Time.deltaTime);

        Vector3 rotate = waypoints[waypointsIndex].position - transform.position;
        Quaternion lockRotation = Quaternion.LookRotation(rotate);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lockRotation, 5 * Time.deltaTime).eulerAngles;
        transform.localRotation = Quaternion.Euler(0, rotation.y, 0);

    }

    void IncreaseIndex()
    {
        waypointsIndex++;

        if (waypointsIndex >= waypoints.Length)
        {
            waypointsIndex = 0;
        }
        
    }
}
