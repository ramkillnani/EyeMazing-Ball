using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //if an object with the tag 'player' collides 
        {
            SceneManager.LoadScene("Win"); //load the said scene

        }



    }
}
