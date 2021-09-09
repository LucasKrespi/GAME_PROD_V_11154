using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Keyboard Variables
    public CharacterController controller;
    public float speed = 12f;

    //Mouse Variables
    public float mouseSenscitivit = 250f;
    public Transform playerBody;
 //  public Camera cameraView;
    float rotationX = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard Controll
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Mouse Controll
        float mouseX = Input.GetAxis("Mouse X") * mouseSenscitivit * Time.deltaTime;
      //  float mouseY = Input.GetAxis("Mouse Y") * mouseSenscitivit * Time.deltaTime;

      //  rotationX -= mouseY;
        //rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        //cameraView.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
