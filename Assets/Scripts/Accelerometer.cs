using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
	public static bool supportsAccelerometer;

	private Rigidbody rb;
	private Vector3 tilt;

	[SerializeField]
	private float speed;

	private void Start()
	{
		rb = GetComponent<Rigidbody>(); // Gets the rigidbody

		if (!supportsAccelerometer)
		{
			// Checks if the current device has an accelorometer at the start, if it doesn't it sets the accelerometer vector3 to 0
			tilt = new Vector3(0, 0, 0);
		}
	}

	private void FixedUpdate()
	{
		if (supportsAccelerometer)
		{
			// Checks if the current device has an accelerometer, and uses it to control the player if the device has one
			tilt = Input.acceleration;
			rb.AddForce(tilt.x * speed, 0, tilt.y * speed);
		}
	}
}
