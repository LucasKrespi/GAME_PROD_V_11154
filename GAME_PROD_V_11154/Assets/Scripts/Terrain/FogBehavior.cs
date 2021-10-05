using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehavior : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
      
        transform.position = GameControl.ship_Transform.position;
    }
}
