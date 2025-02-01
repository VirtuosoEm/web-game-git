using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody rb;
    //private bool isJumping;
    void Start()
    {
        Debug.Log("Перс создался и вызвал CameraFoloww");    

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


    /*private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }*/
}
