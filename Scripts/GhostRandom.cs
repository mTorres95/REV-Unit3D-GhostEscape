using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostRandom : MonoBehaviour
{
    

    // Speed f ghost
    private float speed = 0.3F;
    int i = 0;
    float randX, randZ;
    int goNorth = 1, goSouth = -1, goWest = -1, goEast = 1;
    int zDirection, xDirection;
    Vector3 movement = new Vector3(0, 0, 0);
        

    // Start is called before the first frame update
    void Start()
    {
        zDirection = goNorth;
        xDirection = goWest;
    }

    // Update is called once per frame
    void Update()
    {   
        moveRandomly();
    }

    // When a ghost goes outside the room, it reappears through another wall
    private void OnCollisionEnter(Collision collision)    //called when a rigidbody touches the Box Collider 
    {
        // Did the ghost colide with the border walls ?
       if(collision.collider.tag == "BorderWall"){
                collisionWithBorderWalls();
        }
        
    }

    // Chose a random step and add it to the movement Vector3 to modify the position of each
    // ghost
    private void moveRandomly()
    {   
        if(i==20){
            randX = UnityEngine.Random.Range(-15,15);
            randZ = UnityEngine.Random.Range(-15,15);
            i = 0;
        }
        i++;
                
        movement.x = xDirection*randX;
        movement.z = zDirection*randZ;

        transform.position += movement * Time.deltaTime * speed;
    }

    // Choose randomly where to appear next after having "left" the room
    // Only West, North and South walls, as in East Wall is the Goal
    private void collisionWithBorderWalls(){
        //choose the next wall from where ghost is going to appear
        int wall = UnityEngine.Random.Range(0,3);
        int zWalls = UnityEngine.Random.Range(-7,7);
        int xWalls = UnityEngine.Random.Range(-9,9);
        Vector3 newPosition = new Vector3(0,1.2F,0);
        switch(wall)
        {
            case 0:   //WestBorder
                newPosition.x = -9;
                newPosition.z = zWalls;
                transform.position = newPosition;
                xDirection = goEast;
                break;
            case 1:  //NorthBorder
                newPosition.x = xWalls;
                newPosition.z = (float)6.5;
                transform.position = newPosition;
                zDirection = goSouth;
                break;
            case 2:  //SouthBorder
                newPosition.x = xWalls;
                newPosition.z = (float)-6.5;
                transform.position = newPosition;
                zDirection = goNorth;
                break;
        }
    }
}
