using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehavior : MonoBehaviour
{
    private Transform ship_pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ship_pos = GameObject.Find("Low_poly_UFO").GetComponent<Transform>();

        transform.position = ship_pos.position;
    }
}
