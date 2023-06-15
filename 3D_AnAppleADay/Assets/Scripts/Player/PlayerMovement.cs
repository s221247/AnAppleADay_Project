using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public CharacterController controller;
    //[SerializeField] float speed = 10;

    

    void Update()
    {
        MovePlayer();
    }
    
    // Get unsmoothed input from both axis x & z, keep y at 0 and normalise to stop diagonal movement from being faster.
    // -- REMINDER: enemies may need to be normalised too? --
    void MovePlayer()
    {
        //float vertical = Input.GetAxisRaw("Vertical");
        //float horizontal = Input.GetKey(KeyCode.(W));
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //if (direction.magnitude >= 0.1f)
        {
          //  controller.Move(direction * speed * Time.deltaTime);
        }
    } 
}
