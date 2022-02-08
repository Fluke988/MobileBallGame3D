using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HrushiTileSpawner : MonoBehaviour
{
    public GameObject tilePrefab;
    float xPos, zPos;
    int addVal = 10;

    void Start()
    {
        
    }

    
    void Update()
    {
        xPos = Random.Range(5, 10);
        zPos = Random.Range(5, 10);
        Instantiate(tilePrefab, new Vector3(xPos + addVal, 0, zPos+ addVal), Quaternion.identity);
        addVal += 10;
    }
}
