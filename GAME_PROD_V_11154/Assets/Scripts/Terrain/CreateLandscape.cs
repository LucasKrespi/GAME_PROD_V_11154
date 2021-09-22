using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLandscape : MonoBehaviour
{
   
    //public GameObject landscape_Unity;
    public int width;
    public int half_width;
    public int depht;
    public int half_depht;
    private int num_Cows = 20;
   // public GameObject cow_Prefab;
    // Start is called before the first frame update
    void Start()
    {
        half_depht = depht / 2;
        half_width = width / 2;
        StartLandScape();
       
    }

 
    void StartLandScape()
    {
        
        for (int x = (int)GameControl.ship_Transform.position.x ; x < width + (int)GameControl.ship_Transform.position.x; x++)
            for (int z = (int)GameControl.ship_Transform.position.z; z < depht + (int)GameControl.ship_Transform.position.z; z++)
            {
                //instanciate the cubes in as flat suface, the cube itself updates de position based on the space ship position
                Vector3 unity_pos = new Vector3(x - half_width, 0.0f, z - half_depht);
                    
                GameObject cube = Pool.singletonPool.GetPoolItem("Terrain");
                if(cube != null)
                {
                    cube.SetActive(true);
                    cube.transform.position = unity_pos;
                }
                
            }

    }

    //void spawCows()
    //{
    //    int counter = 0;

    //    while (counter < num_Cows)
    //    {
    //        Vector3 cow_pos = new Vector3(Random.Range(((int)GameControl.ship_Transform.position.x - half_width), ((int)GameControl.ship_Transform.position.x + half_width)),
    //                                      5.0f,
    //                                      Random.Range(((int)GameControl.ship_Transform.position.z - half_depht), ((int)GameControl.ship_Transform.position.z + half_depht)));
    //        GameObject cow = Instantiate(cow_Prefab, cow_pos, Quaternion.identity);
    //    }
    //}

   
}
