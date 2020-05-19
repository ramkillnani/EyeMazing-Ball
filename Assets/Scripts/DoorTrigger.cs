using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
	[SerializeField]
	Animator trigger;
	[SerializeField] //visible in the inspector but the variable is still private
	GameObject door;

	bool isOpened = false; //door is closed by default

	private void OnTriggerEnter(Collider col)
	{
		if (!isOpened) //if the door is not open then-
		{
			isOpened = true;
			door.transform.position += new Vector3(0, 1.392f, 0); //adds 1.392 to the y axis to the objects transform
			trigger.SetBool("isDown", true);
			trigger.SetBool("start", false);
		}
		else
		{
			trigger.SetBool("isDown", true);
			trigger.SetBool("start", false);
		}
	}

	private void OnTriggerExit(Collider colExit)
	{
		trigger.SetBool("isDown", false);
	}
	   
}
