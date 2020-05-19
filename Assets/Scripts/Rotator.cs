using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
     float speed = 50.0f; //speed of the rotation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime); //rotates the object towards the left by speed and real time
    }
}
