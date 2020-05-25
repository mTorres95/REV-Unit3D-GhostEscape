using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script was the first game proposal, in which the walls move and have 3 possibilites:
    - Grow / decrease in size from the North wall, always leaving room for the player to go through
    - Grow / decrease in size from the South wall, always leaving room for the player to go through
    - Start with a random size (within limits) in between the North and South wall, moving up and 
      down, always leaving room for the player to go through
    Each time the Scene was reloaded, each wall would select randomly between one of these behaviors

    The decision to use prefabs made this game proposal difficult to implement, as the size modifi-
    cations affected the prefab, therefore, affected everywall and not just the one wall it was
    supposed to, making it difficult to have different behaviors
*/

public class movingWalls : MonoBehaviour{
    Vector3 wallSize;
    Vector3 wallPosition;
    int mode = 0;
    float zPosMax, zPosMin, zPos;
    float Xscale, scaleMax = 12F, scaleMin = 3F;
    int direction = 1;
    float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        mode = UnityEngine.Random.Range(1,4);
        switch (mode){
            case 1:
                initMovingMiddle();
                break;
            case 2:
                initGrowToSouth();
                break;
            case 3:
                initGrowToNorth();
                break;
        }
             
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode){
            case 1:
                updateMovingMiddle();
                break;
            case 2:
                updateGrowToSouth();
                break;
            case 3:
                updateGrowToNorth();
                break;
        }
    }

    // ========================================================================================
    void initMovingMiddle(){
        // To change the size of the walls, making sure they always leave room for the player to pass
        float randomXscale = UnityEngine.Random.Range(5,11);
        wallSize = new Vector3(randomXscale, transform.localScale.y, transform.localScale.z);
        transform.localScale = wallSize;

        // Position the walls randomly on z-axis, making sure they're within the room
        zPosMax = 7.5F - wallSize.x/2; 
        zPosMin = -7.5F + wallSize.x/2;
        float randomZposition = UnityEngine.Random.Range(zPosMin,zPosMax);
    
        wallPosition = new Vector3(transform.position.x, transform.position.y, randomZposition);
        transform.position = wallPosition;  

        // Each wall will change its position at diferent speed
        speed = UnityEngine.Random.Range(20,80)/10; 
    }

    void updateMovingMiddle(){
        // The wall reached the north wall? Go south
        if(wallPosition.z > (zPosMax - 0.2)) direction = -1;
        // The wall reached the south wall? Go north
        if(wallPosition.z < (zPosMin + 0.2)) direction = 1;
        // Move the walls
        wallPosition.z += direction * Time.deltaTime * speed;
        transform.position = wallPosition;
    }

    void initGrowToSouth(){
        // To change the size of the walls, making sure they always leave room for the player to pass
        Xscale = UnityEngine.Random.Range(4,10);
        wallSize = new Vector3(Xscale, transform.localScale.y, transform.localScale.z);
        transform.localScale = wallSize;

        // Position the walls randomly on z-axis, making sure they're within the room
        zPos = 7.5F - wallSize.x/2; 
        wallPosition = new Vector3(transform.position.x, transform.position.y, zPos);
        transform.position = wallPosition;      

        // Each wall will change its size at diferent speed
        speed = UnityEngine.Random.Range(20,80)/10;
    }

    void updateGrowToSouth(){
        // The wall reached the north wall? Go south
        if(wallSize.x > scaleMax) direction = -1;
        // The wall reached the south wall? Go north
        if(wallSize.x < scaleMin) direction = 1;
        // Move the walls
        Xscale += direction * Time.deltaTime * speed;
        wallSize.x += direction * Time.deltaTime * speed;
        transform.localScale = wallSize;
        wallPosition.z = 7.5F - wallSize.x/2;
        transform.position = wallPosition;
    }

    void initGrowToNorth(){
        // To change the size of the walls, making sure they always leave room for the player to pass
        Xscale = UnityEngine.Random.Range(4,10);
        wallSize = new Vector3(Xscale, transform.localScale.y, transform.localScale.z);
        transform.localScale = wallSize;

        // Position the walls randomly on z-axis, making sure they're within the room
        zPos = -7.5F + wallSize.x/2; 
        wallPosition = new Vector3(transform.position.x, transform.position.y, zPos);
        transform.position = wallPosition;      

        // Each wall will change its size at diferent speed
        speed = UnityEngine.Random.Range(20,80)/10;
    }

    void updateGrowToNorth(){
        // The wall reached the north wall? Go south
        if(wallSize.x > scaleMax) direction = -1;
        // The wall reached the south wall? Go north
        if(wallSize.x < scaleMin) direction = 1;
        // Move the walls
        Xscale += direction * Time.deltaTime * speed;
        wallSize.x += direction * Time.deltaTime * speed;
        transform.localScale = wallSize;
        wallPosition.z = -7.5F + wallSize.x/2;
        transform.position = wallPosition;
    }
}
