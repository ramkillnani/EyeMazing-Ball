using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    Animator trigger;
    [SerializeField] //visible in the inspector but the variable is still private
    GameObject door;

    public Material changeDisolve;

    private float shaderValue = 1f;
    private float change = 0.01f;
    private float delay = 0.0f;

    private void Start()
    {
        
    }

    private void Awake()
    {
        changeDisolve.SetFloat("Visibility", 1f);
    }

    IEnumerator ChangeShader()
    {
        while (shaderValue > 0f)
        {
            yield return new WaitForSeconds(delay);

            if (door.GetComponent<MeshRenderer>().material = changeDisolve)
            {
                shaderValue -= change;
                changeDisolve.SetFloat("Visibility", shaderValue);
            }
        }

        if (shaderValue <= 0f)
        {
            Destroy(door);
        }

    }


    bool isOpened = false; //door is closed by default


    private void OnTriggerEnter(Collider col)
    {
        StartCoroutine(ChangeShader());

        if (!isOpened) //if the door is not open then-
        {
            isOpened = true;
            //door.transform.position += new Vector3(0, 1.392f, 0); //adds 1.392 to the y axis to the objects transform
            trigger.SetBool("isDown", true);
            trigger.SetBool("start", false);
        }
        else
        {
            trigger.SetBool("isDown", true);
            trigger.SetBool("start", false);
        }

        door.GetComponent<Renderer>().material = changeDisolve;
        

        //Destroy(door, 1.5f);
    }

    private void OnTriggerExit(Collider colExit)
    {
        trigger.SetBool("isDown", false);
    }

}
