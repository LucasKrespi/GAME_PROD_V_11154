using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownCamera : MonoBehaviour
{
    public Camera TopDownCamera;
    private bool isCameraenable = true;
    // Start is called before the first frame update
    void Start()
    {
        TopDownCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TopDownCamera.enabled = isCameraenable;
            isCameraenable = !isCameraenable;
        }
    }
}
