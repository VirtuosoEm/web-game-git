using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody rb;
    //private bool isJumping;
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
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }*/
}
