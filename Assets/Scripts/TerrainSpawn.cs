using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawn : MonoBehaviour
{
    //a list of all the terrain prefabs
    public GameObject[] terrainPrefabs;
    [SerializeField] Transform cameraTransform;
    int terrainIndex = 0;

    private void Update() {
        // if camera transform y is greater than the current terrain's transform, spawn a new terrain and move the spawner 2 units up
        if (cameraTransform.position.y > transform.position.y) {
            SpawnTerrain();
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            
        }
    }

    void SpawnTerrain() {
        // spawn a new terrain prefab
        Instantiate(terrainPrefabs[terrainIndex], transform.position, Quaternion.identity);
        // increment the terrain index
        terrainIndex++;
        // if the terrain index is greater than the length of the terrain prefabs, reset the terrain index to 0
        if (terrainIndex >= terrainPrefabs.Length) {
            terrainIndex = 0;
        }
    }
}
