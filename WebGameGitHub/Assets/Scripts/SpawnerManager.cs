using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] player;
    public Transform spawnPoint;


    void Start()
    {
        
        Instantiate(player[PlayerPrefs.GetInt("Ball")],spawnPoint.position, spawnPoint.rotation);
        CameraFollow.playerInGame = true;

    }

}
