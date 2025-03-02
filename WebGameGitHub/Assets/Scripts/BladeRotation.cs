using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BladeRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;   
    private bool backRotate;
    private float randomRange;
    private bool randomBool;
    public bool isMoney;
    public bool isMolot;
    public bool isFan;

    private void Start()
    {
        randomRange = Random.Range(95, 125);
        randomBool = Random.value > 0.5f;
    }
    private void FixedUpdate()
    {
        if (isMoney)
        {
            if (!randomBool)
            {
                //transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                transform.Rotate(0, randomRange * Time.deltaTime, 0);
            }
            else if (randomBool)
            {
                //transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
                transform.Rotate(0, transform.rotation.y - randomRange * Time.deltaTime, 0);
            }
        }
        if (isMolot)
        {
            if (!backRotate)
            {
                //transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
            else if (backRotate)
            {
                //transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
                transform.Rotate(0, transform.rotation.y - rotationSpeed * Time.deltaTime, 0);
            }
        }
        if (isFan)
        {
            if (!backRotate)
            {
                //transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
            else if (backRotate)
            {
                //transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
                transform.Rotate(0, transform.rotation.y - rotationSpeed * Time.deltaTime, 0);
            }
        }

    }


}
