using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //for switches scenes

public class LevelControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //if an object with the tag 'player' collides 
        {
            SceneManager.LoadScene("Level2"); //load the said scene

        }



    }



}
