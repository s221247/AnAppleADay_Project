using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For consistency of camera movement when player moves
public class PlayerCamera : MonoBehaviour
{
    // Mouse movement sensitivity
    public float sensX;
    public float sensY;

    // Player orientation
    public Transform orientation;

    // Camera rotation
    float xRotation;
    float yRotation;

    // Lock cursor and make invisible
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Get mouse input, multiply by frames & sensitivity (set in Inspector!) and set camera movement to limited rotation.
    void Update()
    {
        // Mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // CONFUSING AS ALWAYS BUT Camera rotates around Y axis if mouse moves "left/right", so must add and equal
        yRotation += mouseX;

        // x axis takes care of "up/down" rotation, minus and equal. 
        // Need to "clamp" rotation so it doesn't go wacky
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate camera on both axis, only rotate player on Y axis
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
