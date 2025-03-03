using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BladeRotation : MonoBehaviour
{
    
    [SerializeField] private float targetScale = 1.5f; // Целевой размер
    [SerializeField] private float scaleDuration = 1f; // Длительность анимации
    [SerializeField] private bool loop = true; // Повторять анимацию?

    private Vector3 originalScale;
    private float currentTime = 0;
    private bool isScalingUp = true;

    public float rotationSpeed = 10f;   
    public bool backRotate;
    private float randomRange;
    private bool randomBool;
    public bool isMoney;
    public bool isMolot;
    public bool isFan;

    private void Start()
    {
        randomRange = Random.Range(95, 125);
        randomBool = Random.value > 0.5f;
        originalScale = transform.localScale;
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
            if (isScalingUp)
            {
                transform.localScale = Vector3.Lerp(originalScale, new Vector3(targetScale, targetScale, targetScale), currentTime / scaleDuration);
                currentTime += Time.deltaTime;

                if (currentTime >= scaleDuration)
                {
                    isScalingUp = false;
                    currentTime = 0;
                }
            }
            else
            {
                transform.localScale = Vector3.Lerp(new Vector3(targetScale, targetScale, targetScale), originalScale, currentTime / scaleDuration);
                currentTime += Time.deltaTime;

                if (currentTime >= scaleDuration)
                {
                    isScalingUp = true;
                    currentTime = 0;

                    if (!loop)
                    {
                        enabled = false;
                    }
                }
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
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                //transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
            else if (backRotate)
            {
                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
                //transform.Rotate(0, transform.rotation.y - rotationSpeed * Time.deltaTime, 0);
            }
        }

    }


}
