using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>(); //list that holds the waypoints
    private Transform targetWaypoint; //holds the current waypoint the enemy is walking towards
    private int targetWaypointIndex = 0; //the first waypoint on the element array
    private float minDistance = 0.1f; //if the enemy has reached the waypoint (min distance = the waypoint)
    private int lastWaypointIndex; //the last waypoint in the index

    private float movementSpeed = 20.0f; //speed the enemy moves between waypoints

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex]; //on start the enemy moves to-


    }

    // Update is called once per frame
    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime; //movespeed * time for it to happen every frame.

        float distance = Vector3.Distance(transform.position, targetWaypoint.position); //check distance to the waypoint
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

        
        
    }

    void CheckDistanceToWaypoint(float currentDistance) //checks the distance between waypoints
    {
        if(currentDistance <= minDistance)
        {
            targetWaypointIndex++; //goes to the next Waypoint on the index
            UpdateTargetWaypoint();
        }


    }

    void UpdateTargetWaypoint() //updates which waypoint the enemy is going towards.
    {
        if(targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level2");
        }
    }


}
