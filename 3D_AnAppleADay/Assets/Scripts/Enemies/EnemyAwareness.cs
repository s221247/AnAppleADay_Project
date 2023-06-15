using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public bool AwareofPlayer { get; private set; }
    public Vector3 DirectionOfPlayer { get; private set; }

    [SerializeField] float awarenessDistance;
    private Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyToPlayerVector = player.position - transform.position;
        DirectionOfPlayer = enemyToPlayerVector.normalized;

        AwareofPlayer = (enemyToPlayerVector.magnitude <= awarenessDistance);

        // Old convoluted way of as above - redundant to say it's true/false when it's true
        //if (enemyToPlayerVector.magnitude <= awarenessDistance)
        //{
        //    AwareofPlayer = true;
        //}
        //
        //else
        //{
        //    AwareofPlayer = false;
        //}

    }

}
