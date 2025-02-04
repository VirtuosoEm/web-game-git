using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public static CameraFollow instance;
   
    private GameObject player; 
    private Vector3 offset;
   
    private bool playerFollow;
    public static bool playerInGame;
    private bool odinRaz;
    void Start()
    {
        playerFollow = false;
        /*player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;*/
        //Invoke("PlayerSearch", 0.1f);
    }
    

    void LateUpdate()
    {
        if (!odinRaz && playerInGame)
        {
            PlayerSearch();
            odinRaz = true;
        }
        if (playerFollow == true)
        {
            //transform.position = player.transform.position + offset;
            transform.position = player.transform.position + offset;
            //transform.position = new Vector3(offset.x, offset.y + 10f, offset.z - 5f);
        }      
    }
    public void PlayerSearch()
    {     
        player = GameObject.FindWithTag("Player");
        
        offset = new Vector3(0, 9, -9); 
        //offset = ofSet + new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        //offset = player.transform.position + new Vector3(ofSet.x, ofSet.y +10f, ofSet.z);
        //offset = player.transform.position;

        //offset = transform.position - player.transform.position;
        playerFollow = true;
    }


}
