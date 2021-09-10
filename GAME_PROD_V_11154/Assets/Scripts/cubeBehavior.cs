using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBehavior : MonoBehaviour
{
    public Transform ship_pos;
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        ship_pos = GameObject.Find("Low_poly_UFO").GetComponent<Transform>();
        if (this.transform.position.x > (int)ship_pos.position.x + 10
                  || this.transform.position.x < (int)ship_pos.position.x - 10
                  || this.transform.position.z > (int)ship_pos.position.z + 10
                  || this.transform.position.z < (int)ship_pos.position.z - 10)
        {
            this.gameObject.SetActive(false);
        }
    }
}
