using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tilePrefabs;
    public Transform playerTransform;
    private float zSpawn;
    public float tileLength = 16f;
    private int numbersOfTile = 5;

    void Start()
    {
        for (int i = 0; i < tilePrefabs.Length; i++) 
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > zSpawn - (numbersOfTile * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
        
    }
    private void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], Vector3.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }
}
