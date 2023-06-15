using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform cameraPosition;

    // For ease of all the lights and etc following the player; they follow the empty object instead of the rigid
    void Update()
    {
        transform.position = cameraPosition.position;    
    }
}
