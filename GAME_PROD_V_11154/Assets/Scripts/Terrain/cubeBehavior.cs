using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBehavior : MonoBehaviour
{
     private int x_initial;
    private int z_initial;

 

    // Start is called before the first frame update
    void Start()
    {
       x_initial = (int)transform.position.x;
       z_initial = (int)transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateCubePosition(GameControl.ship_Transform);
    }

    void UpdateCubePosition(Transform ship_pos)
    {

        // get the x and z position based on the ship
        int x = x_initial + (int)ship_pos.position.x;
        int z = z_initial + (int)ship_pos.position.z;

        // set the x and z and calculates and sets the y based on the x and z position 
        transform.position = new Vector3(x,
                                         Mathf.PerlinNoise(x * 0.2f, z * 0.2f) * 3.75f,
                                         z);
    }
}
