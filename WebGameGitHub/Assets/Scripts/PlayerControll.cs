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
    private float windSpeed = 5f;
    private bool wind;
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
        if (wind)
        {
            transform.position += windDirection * windSpeed * Time.deltaTime;
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
        if (other.gameObject.tag == "Wind")
        {
            wind = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wind")
        {
            wind = false;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }*/
}
