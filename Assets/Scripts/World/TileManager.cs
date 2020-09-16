using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;

    private List<GameObject> activeTiles;
    private Transform playerTransform;

    private float spawnZ = 0.0f;
    private float tileLength = 80.0f;
    private int tileNumber = 10;
    private float safeZone = 130.0f;

    private int numRoads = 21;
    private int firstTile = 0;

    void Start(){
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < tileNumber; i++){
            SpawnTile();
        }
    }

    void Update(){
        if(playerTransform.position.z - safeZone > (spawnZ - tileNumber * tileLength)){
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1){
        int randomInt;
        if(firstTile == 0){
            firstTile = -1;
            randomInt = 0;
        }
        else {
            randomInt = Random.Range(0, numRoads);
        }

        GameObject go;
        go = Instantiate(tilePrefabs[randomInt]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;

        activeTiles.Add(go);
    }

    private void DeleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
