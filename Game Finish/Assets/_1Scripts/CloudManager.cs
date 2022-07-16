using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] private float cloudSpawnTimer = 1f;
    private float rememberCloudTime;

    //non dynamic array holding clouds for now
    [SerializeField] GameObject [] cloudArray = new GameObject[5];

    [SerializeField] private int randomCloudHeight = 30;
    [SerializeField] private int randomCloudHeightFactor = 100;
    [SerializeField] private int randomCloudWidthFactor = 1000;
    private int randomCloud;
    private int randomHeight;
    private int randomWidth;

    GameObject gameTerrain;
    Vector3 terrainSize;
    GameObject cloudMover;

    void Start()
    {
        //make our timer remember through code so we only have to change "cloudSpawnTimer" in editor
        rememberCloudTime = cloudSpawnTimer;

        //dynmaically grab terrain and set up cloud manager in the middle of the terrain to spawn in the right position

        gameTerrain = GameObject.Find("Terrain");
        terrainSize = gameTerrain.GetComponent<Terrain>().terrainData.size;
        terrainSize.x = terrainSize.x / 2;
        terrainSize.y = terrainSize.y * 5;
        transform.position = terrainSize;
        
        //grab a refference to the cloudmover
        cloudMover = GameObject.Find("CloudMover");
    }

    // Update is called once per frame
    void Update()
    {
        cloudSpawnTimer -= Time.deltaTime;
        if(cloudSpawnTimer <= 0)
        {
            SpawnCloud();
            cloudSpawnTimer = rememberCloudTime;
        }
    }

    private void SpawnCloud()
    {
        randomCloud = Random.Range(0, cloudArray.Length);
        randomHeight = Random.Range(-randomCloudHeight, randomCloudHeight) + randomCloudHeightFactor;
        randomWidth = (int)Random.Range(-terrainSize.x - randomCloudWidthFactor, terrainSize.x + randomCloudWidthFactor);
        Vector3 spawnPos = new Vector3(terrainSize.x + randomWidth, terrainSize.y + randomHeight, transform.position.z);
        GameObject prefab = Instantiate(cloudArray[randomCloud], spawnPos, Quaternion.identity);
        prefab.transform.parent = cloudMover.transform;
        Debug.Log("Success");

    }

}
