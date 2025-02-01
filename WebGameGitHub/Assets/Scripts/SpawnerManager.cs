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
        Instantiate(player[0],spawnPoint.position, spawnPoint.rotation);

    }

}
