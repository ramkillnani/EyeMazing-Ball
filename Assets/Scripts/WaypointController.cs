using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaypointController : MonoBehaviour
{
	public List<Transform> waypoints = new List<Transform>(); //list that holds the waypoints
	public GameObject enemy;
	public Rigidbody enemyRigid;

	[SerializeField]
	private float movementSpeed = 20.0f; //speed the enemy moves between waypoints

	private Transform targetWaypoint; //holds the current waypoint the enemy is walking towards
	private int targetWaypointIndex = 0; //the first waypoint on the element array
	private float minDistance = 0.1f; //if the enemy has reached the waypoint (min distance = the waypoint)
	private int lastWaypointIndex; //the last waypoint in the index	

	public float xSpeedPerSec;
	private float xSpeed;
	private Vector3 xOldPos;
	public float zSpeedPerSec;
	private float zSpeed;
	private Vector3 zOldPos;

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

		EnemyRotation();
	}

	void CheckDistanceToWaypoint(float currentDistance) //checks the distance between waypoints
	{
		if (currentDistance <= minDistance)
		{
			targetWaypointIndex++; //goes to the next Waypoint on the index
			UpdateTargetWaypoint();
		}
	}

	void UpdateTargetWaypoint() //updates which waypoint the enemy is going towards.
	{
		if (targetWaypointIndex > lastWaypointIndex)
		{
			targetWaypointIndex = 0;
		}
		targetWaypoint = waypoints[targetWaypointIndex];
	}

	#region Enemy

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			SceneManager.LoadScene("Level2");
		}
	}

	void EnemyRotation()
	{
		//enemy.transform.rotation = new Quaternion(enemyRigid.velocity.x * Time.deltaTime, enemyRigid.velocity.y * Time.deltaTime, enemyRigid.velocity.z * Time.deltaTime, 0);

		//speed = Vector3.Distance(oldPos, transform.position);
		xSpeedPerSec = Vector3.Distance(xOldPos, new Vector3(enemy.transform.position.x, 0f, 0f)) / Time.deltaTime;
		xOldPos = new Vector3(enemy.transform.position.x, 0f, 0f);

		zSpeedPerSec = Vector3.Distance(zOldPos, new Vector3(0f, 0f, enemy.transform.position.z)) / Time.deltaTime;
		zOldPos = new Vector3(0f, 0f, enemy.transform.position.z);
	}

	#endregion
}
