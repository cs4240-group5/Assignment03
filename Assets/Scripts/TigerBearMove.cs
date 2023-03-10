using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBearMove : MonoBehaviour
{
    public float speed = 0.1f; 
    private Animator animator; 
    private Vector3 movementDirection = Vector3.forward; 

    void Start()
    {
        animator = GetComponent<Animator>(); // Get reference to the Animator component on this object
        animator.SetBool("isMoving", true); // Set the "isMoving" parameter to true to start the animation
    }

    void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World); // Move the object forward
        transform.Rotate(new Vector3(0,0.1f,0));
        movementDirection = transform.forward;
        

        /*if (counter > 400)
        {

            transform.Rotate(new Vector3(0,180.0f,0));
            movementDirection = transform.forward;
            counter = 0;
        }*/
    }
}
