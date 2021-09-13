using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Keyboard Variables
   
    private float speed = 500f;

    //Mouse Variables
    private float mouseSenscitivit = 100f;
    public Transform playerBody;

    //physics variables
    public Rigidbody playerRigidbody;

    //gun variables
    public ParticleSystem muzzeflash;

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

        playerRigidbody.AddForce(move * speed * Time.deltaTime);

        //Mouse Controll
        float mouseX = Input.GetAxis("Mouse X") * mouseSenscitivit * Time.deltaTime;
     
        playerBody.Rotate(Vector3.up * mouseX);

        //Slow ship
        if (Input.GetButtonDown("Brake"))
        {
            playerRigidbody.velocity = Vector3.zero;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("FIRE");
            muzzeflash.Play(); 
        }
    }
}
