using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zWalls : MonoBehaviour
{
    public GameObject z_wall;
    float [] zPos = {-6.25F, -3.75F, -1.25F, 1.25F, 3.75F, 6.25F};

    // Start is called before the first frame update
    void Start()
    {
        // Rotate fences so they're on the x-axis
        transform.Rotate(new Vector3(-90f,90f, 0f));

        float xPos = -8;
        // Create fences for the z-axis
        for(int i=0; i<9; i++){
            initWalls(xPos);
            xPos +=2;
        }
    }

    void initWalls(float column){
        List<float> alreadyUsed = new List<float>();
        for(int i=0; i<2;i++){
            int index = UnityEngine.Random.Range(0,6);
            // Make sure a fence isn't initiated in the same place as another
            if(!alreadyUsed.Contains(index)){
                Vector3 wallPosition = new Vector3(column, 0, zPos[index]);
                Instantiate(z_wall, wallPosition, transform.rotation);
                alreadyUsed.Add(index);
            }
        }
    }
}
