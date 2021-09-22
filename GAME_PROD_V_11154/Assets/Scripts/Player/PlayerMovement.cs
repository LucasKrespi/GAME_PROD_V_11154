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
    private bool cowhit = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard Controll

        if (!cowhit)
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            playerRigidbody.AddForce(move * speed * Time.deltaTime);
        }

        //Mouse Controll
        float mouseX = Input.GetAxis("Mouse X") * mouseSenscitivit * Time.deltaTime;
     
        playerBody.Rotate(Vector3.up * mouseX);

        //Slow ship
        if (Input.GetButtonDown("Brake"))
        {
            playerRigidbody.velocity = Vector3.zero;
        }

        //Abduction
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                if(hit.rigidbody != null)
                {
                    cowhit = true;
                    playerRigidbody.velocity = Vector3.zero;

                    hit.rigidbody.velocity = new Vector3(0.0f, 1.0f, 0.0f);
                  
                    hit.rigidbody.useGravity = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "cow")
        {
            Destroy(collision.gameObject);
            cowhit = false;
            muzzeflash.Play();
        }
    }

}
