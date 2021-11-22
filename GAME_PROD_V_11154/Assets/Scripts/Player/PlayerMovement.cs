using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Keyboard Variables
   
    private float speed = 500f;
    private float maxVelocity = 10;

    //Mouse Variables
    private float mouseSenscitivit = 100f;
    public Transform playerBody;

    //physics variables
    public Rigidbody playerRigidbody;

    //gun variables
    public ParticleSystem muzzeflash;
    public bool cowhit = false;

    //Hud and game control
    public int score;
    public int cowsCounter = 0;
    public int lives = 5;

    //Souds
    public SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
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
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                if(hit.rigidbody != null)
                {
                    cowhit = true;
                    playerRigidbody.velocity = Vector3.zero;

                    hit.rigidbody.velocity = new Vector3(0.0f, 2.0f, 0.0f);
                  
                    hit.rigidbody.useGravity = false;

                    soundManager.PlaySound("Moo"); 
                    soundManager.PlaySound("Abduction");
                }
            }
        }

        //limit velocity

        if (playerRigidbody.velocity.magnitude > maxVelocity)
        {
            playerRigidbody.velocity *= 0.9f;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("cow"))
        {
            //Put cow back to the pool, and reseting initial settings
            resetToPoll(collision);
            score = score + 100;
            muzzeflash.Play();
            cowsCounter++;

            if(cowsCounter % 10 == 0)
            {
                FindObjectOfType<GameControl>().timer = FindObjectOfType<GameControl>().timer + 20;
            }
        }

        if (collision.gameObject.CompareTag("meteor"))
        {
            lives--;

            FindObjectOfType<GameControl>().timer = FindObjectOfType<GameControl>().timer - 20;

            soundManager.PlaySound("MeteorExplosion");
        }
    }

    private void resetToPoll(Collision collision)
    {
        collision.gameObject.SetActive(false);
        collision.rigidbody.useGravity = true;
        collision.rigidbody.velocity = Vector3.zero;
        collision.transform.rotation = Quaternion.identity;
        cowhit = false;
    }
}
