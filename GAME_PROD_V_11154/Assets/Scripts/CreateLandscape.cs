using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLandscape : MonoBehaviour
{
    public Transform ship_pos;
    //public GameObject landscape_Unity;
    public int width;
    public int half_width;
    public int depht;
    public int half_depht;
    // Start is called before the first frame update
    void Start()
    {
        half_depht = depht / 2;
        half_width = width / 2;
        ship_pos = GameObject.Find("Low_poly_UFO").GetComponent<Transform>();
        StartLandScape();
    }

    // Update is called once per frame
    void Update()
    {

       // UpdateLandScapePosition;
    }

    void StartLandScape()
    {
        for (int x = (int)ship_pos.position.x ; x < width + (int)ship_pos.position.x; x++)
            for (int z = (int)ship_pos.position.z; z < depht + (int)ship_pos.position.z; z++)
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

    void UpdateLandScapePosition()
    {

    }
}
