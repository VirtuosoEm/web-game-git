using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevel1 : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public GameObject wall;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            wall.SetActive(false);
            Destroy(gameObject);

            /*if (triggers[0] == true)
            {
                triggers[0].SetActive(false);
                triggers[1].SetActive(true);
                wall[0].SetActive(false);
            }
            if (triggers[1] == true)
            {
                triggers[1].SetActive(false);
                triggers[2].SetActive(true);
                
            }
            if (triggers[2] == true)
            {
                triggers[2].SetActive(false);
                triggers[3].SetActive(true);
                wall[1].SetActive(false);
            }
            if (triggers[3] == true)
            {
                triggers[3].SetActive(false);
                triggers[4].SetActive(true);
               
            }
            if (triggers[4] == true)
            {
                triggers[4].SetActive(false);
                wall[2].SetActive(false);

            }*/

        }
    }
}
