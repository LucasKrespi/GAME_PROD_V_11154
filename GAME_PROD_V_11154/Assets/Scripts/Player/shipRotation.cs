using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipRotation : MonoBehaviour
{
    public GameObject shipBody;
    public float rotationSpeed = 1;
 
    private void FixedUpdate()
    {
        shipBody.transform.Rotate(new Vector3(0f,0f, rotationSpeed)); 
    }
}
