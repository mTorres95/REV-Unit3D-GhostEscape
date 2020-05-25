using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    Transform player;
    float rotSpeed = 1.0F; // the speed of the ghost to rotate towards the player
    float moveSpeed = 1.0F; // the speed of the ghost to move towards the player

    // Start is called before the first frame update
    void Start()
    {
        // Find the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Look towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, 
                                              Quaternion.LookRotation(player.position - transform.position),
                                              rotSpeed * Time.deltaTime); 

        // Move towards the player
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
