using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xWalls : MonoBehaviour
{
    public GameObject x_wall;
    float [] zPos = {-5.0F, -2.5F, 0.0F, 2.5F, 5.0F}; // The possible positions on z for the walls in each row 
    
    // Start is called before the first frame update
    void Start()
    {
            float xPos = -7;
            // Rotate walls so they're on the x-axis
            transform.Rotate(new Vector3(0f,0f, 0f));
            // Create the walls for the 8 rows
            for(int i=0; i<8; i++){
                // Instantiate the walls for each row
                xWallInstantiation(xPos);
                xPos += 2;
            }
    }

    void xWallInstantiation(float xPos){
        List<float> alreadyUsed = new List<float>();
        for(int i=0; i<3;i++){
            int index = UnityEngine.Random.Range(0,5);
            // Make sure a wall isn't instantiated in the same place as another
            if(!alreadyUsed.Contains(index)){    
                // Position the walls randomly on z-axis, making sure they're within the room
                Vector3 wallPosition = new Vector3(xPos, transform.position.y, zPos[index]);
                // Instantiate the walls
                Instantiate(x_wall, wallPosition, transform.rotation);
            }
            alreadyUsed.Add(index);
        }

    }
}
