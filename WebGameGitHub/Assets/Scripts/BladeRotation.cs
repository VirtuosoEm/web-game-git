using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BladeRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public bool backRotate;

    
    private void FixedUpdate()
    {
        if (!backRotate)
        {
            //transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            transform.Rotate(0,rotationSpeed * Time.deltaTime, 0);
        }
        else if (backRotate)
        {
            //transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            transform.Rotate(0,transform.rotation.y - rotationSpeed * Time.deltaTime, 0);
        }

    }


}
