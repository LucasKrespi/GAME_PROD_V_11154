using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static Transform ship_Transform;
    public static GameControl singletonGamecontrol;

    public static List<Vector3> Occupied_pos;

    public float V1 = 0.2f;
    public float V2 = 3.75f;

    private void Awake()
    {
        singletonGamecontrol = this;
    }
    private void Start()
    {
        ship_Transform = GameObject.Find("Low_poly_UFO").GetComponent<Transform>();
        Occupied_pos = new List<Vector3>(Pool.singletonPool.pooledItens.Count);
    }
    void Update()
    {
        ship_Transform = GameObject.Find("Low_poly_UFO").GetComponent<Transform>();
        
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

    }

    public float Noise(int x, int y)
    {
        float temp = Mathf.PerlinNoise(x * V1, y * V1) * V2;
        return temp;
    }

    public static bool isPosOccupied(Vector3 tested)
    {
        foreach(Vector3 t in Occupied_pos)
        {
            if( tested.x + 2 <= t.x &&
                tested.x - 2 >= t.x &&
                tested.z + 2 <= t.z &&
                tested.z - 2>= t.z )
            {
                return true;
            }
        }

        return false;
    }
}
