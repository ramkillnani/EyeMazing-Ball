using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; //difference between player and camera
    }

    // runs after all items is processed in update
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //as the player moves the camera is moved to a new position alligned to the player object
    }
}
