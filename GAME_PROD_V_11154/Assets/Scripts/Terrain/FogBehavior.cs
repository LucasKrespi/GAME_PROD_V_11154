using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehavior : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.position = GameControl.ship_Transform.position;
    }
}
