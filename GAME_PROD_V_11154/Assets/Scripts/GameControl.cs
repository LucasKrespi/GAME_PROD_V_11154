using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static Transform ship_Transform;

    private void Start()
    {
        ship_Transform = GameObject.Find("Low_poly_UFO").GetComponent<Transform>();
    }
    void Update()
    {
        ship_Transform = GameObject.Find("Low_poly_UFO").GetComponent<Transform>();
        
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
            Debug.Log("QUIT");
        }

    }
}
