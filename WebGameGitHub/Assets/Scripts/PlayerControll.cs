using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody rb;
    //private bool isJumping;


    //* �������� ������
    private Vector3 windDirection = Vector3.right;
    private Vector3 windLeftDirection = Vector3.left;
    public float windSpeed = 5f;
    private bool windRight;
    private bool windLeft;

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

       
    }*/ //������

    private void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) // ����� ����������� �����
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
        /*if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("������");
            rb.AddForce(movement * 1000);
        }*/

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //�������� �� ����� �� ������� ���
        }
        if (other.gameObject.tag == "WindRight")
        {
            windRight = true;
        }
        if (other.gameObject.tag == "WindLeft")
        {
            windLeft = true;
        }
        if (other.gameObject.tag == "Money")
        {
            Destroy(other.gameObject);
            SelectItems._money++;
            Debug.Log("�����" + SelectItems._money);
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
