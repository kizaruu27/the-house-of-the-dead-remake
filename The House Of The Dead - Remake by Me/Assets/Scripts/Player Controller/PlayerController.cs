using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] waypoints;
    public float turnSpeed = 20f;
    public bool canMove;

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

        canMove = true;

    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[waypointsIndex].position);


        if (distance < 0.05f)
        {
            IncreaseIndex();
        }

        if (canMove)
        {
            StartCoroutine(Patrol());
        }
        else
        {
            StopCoroutine(Patrol());
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Waypoint")
        {
            canMove = false;
            //other.GetComponent<BoxCollider>().enabled = false;
        }    
    }

    IEnumerator Patrol()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].position, speed * Time.deltaTime);

        Vector3 rotate = waypoints[waypointsIndex].position - transform.position;
        Quaternion lockRotation = Quaternion.LookRotation(rotate);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lockRotation, 5 * Time.deltaTime).eulerAngles;
        transform.localRotation = Quaternion.Euler(0, rotation.y, 0);

        yield return new WaitForSeconds(0);
        

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
