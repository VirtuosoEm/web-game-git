using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody rb;
    //private bool isJumping;


    //* смещение ветром
    private Vector3 windDirection = Vector3.right;
    private Vector3 windLeftDirection = Vector3.left;
    private float windSpeed = 5f;
    private bool windRight;
    private bool windLeft;
    //*

    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        //isJumping = false;
    }

    /*private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.velocity = new Vector3(0, 5, 0);
            isJumping = true;
        }

       
    }*/ //Прыжок

    private void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) // смена направления ветра
        {
            windDirection = -windDirection;
        }*/
        if (windRight)
        {
            transform.position += windDirection * windSpeed * Time.deltaTime;
        }
        if (windLeft)
        {
            transform.position += windLeftDirection * windSpeed * Time.deltaTime;
        }
       

        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            SceneManager.LoadScene(1);
        }
        if (other.gameObject.tag == "WindRight")
        {
            windRight = true;
        }
        if (other.gameObject.tag == "WindLeft")
        {
            windLeft = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "WindRight")
        {
            windRight = false;
        }
        if (other.gameObject.tag == "WindLeft")
        {
            windLeft = false;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }*/
}
