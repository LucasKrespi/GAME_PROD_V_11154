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
    public GameObject terrain_prefab;

    private int spawnSafeArea = 10;
    // Start is called before the first frame update
    void Start()
    {
        half_depht = depht / 2;
        half_width = width / 2;
        StartLandScape();
        spawTrees();
        spawCows();
    }


    private void Update()
    {
        spawCows();
        spawTrees();
    }
    void StartLandScape()
    {
        
        for (int x = (int)GameControl.ship_Transform.position.x ; x < width + (int)GameControl.ship_Transform.position.x; x++)
            for (int z = (int)GameControl.ship_Transform.position.z; z < depht + (int)GameControl.ship_Transform.position.z; z++)
            {
                //instanciate the cubes in as flat suface, the cube itself updates de position based on the space ship position
                Vector3 unity_pos = new Vector3(x - half_width, 0.0f, z - half_depht);
                Instantiate(terrain_prefab, unity_pos, Quaternion.identity);             
                
            }

    }

    void spawCows()
    {
      

        while(true)
        {
            int x_pos1 = Random.Range(((int)GameControl.ship_Transform.position.x - half_width), ((int)GameControl.ship_Transform.position.x - spawnSafeArea));
            int z_pos1 = Random.Range(((int)GameControl.ship_Transform.position.z - half_depht), ((int)GameControl.ship_Transform.position.z - spawnSafeArea));

            int x_pos2 = Random.Range(((int)GameControl.ship_Transform.position.x + half_width), ((int)GameControl.ship_Transform.position.x + spawnSafeArea));
            int z_pos2 = Random.Range(((int)GameControl.ship_Transform.position.z + half_depht), ((int)GameControl.ship_Transform.position.z + spawnSafeArea));

            int x_pos = Random.Range((int)x_pos1, (int)x_pos2);
            int z_pos = Random.Range((int)z_pos1, (int)z_pos2);

            Vector3 cow_pos = new Vector3(x_pos , (GameControl.singletonGamecontrol.Noise(x_pos, z_pos) + 0.5f) , z_pos);

            if (!GameControl.isPosOccupied(cow_pos))
            {

                GameObject cow = Pool.singletonPool.GetPoolItem("cow");
                if (cow != null)
                {
                    cow.GetComponent<CowBehavior>().OnTakeFromPool(cow_pos);
                }
            
                if(cow == null)
                {
                    break;
                }
            }
            
        }
    }


    void spawTrees()
    {


        while (true)
        {
            int x_pos1 = Random.Range(((int)GameControl.ship_Transform.position.x - half_width), ((int)GameControl.ship_Transform.position.x - spawnSafeArea));
            int z_pos1 = Random.Range(((int)GameControl.ship_Transform.position.z - half_depht), ((int)GameControl.ship_Transform.position.z - spawnSafeArea));

            int x_pos2 = Random.Range(((int)GameControl.ship_Transform.position.x + half_width), ((int)GameControl.ship_Transform.position.x + spawnSafeArea));
            int z_pos2 = Random.Range(((int)GameControl.ship_Transform.position.z + half_depht), ((int)GameControl.ship_Transform.position.z + spawnSafeArea));

            int x_pos = Random.Range((int)x_pos1, (int)x_pos2);
            int z_pos = Random.Range((int)z_pos1, (int)z_pos2);

            Vector3 tree_pos = new Vector3(x_pos,
                                          GameControl.singletonGamecontrol.Noise(x_pos, z_pos) + 0.5f,
                                          z_pos);

            if(!GameControl.isPosOccupied(tree_pos))
            {

                GameObject tree = Pool.singletonPool.GetPoolItem("tree");
                if (tree != null)
                {
                    tree.GetComponent<TreeBehavior>().OnTakeFromPool(tree_pos);
                }

                if (tree == null)
                {
                    break;
                }
            }

        }
    }


}
