using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BladeRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public bool backRotate;

    
    private void FixedUpdate()
    {
        if (!backRotate)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else if (backRotate)
        {
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            SceneManager.LoadScene(1);
        }
    }
}
