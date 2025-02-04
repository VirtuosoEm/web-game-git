using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerManager : MonoBehaviour
{

    public int playerId;
    public GameObject[] player;
    public Transform spawnPoint;


    void Start()
    {
        Instantiate(player[playerId],spawnPoint.position, spawnPoint.rotation);
        CameraFollow.playerInGame = true;

    }

}
