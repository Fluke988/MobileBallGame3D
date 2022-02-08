using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject tile;
    float xPos=0f, zPos=0f, previousX,previousZ;
    public float add;
    
    void Start()
    {
        Instantiate(tile, new Vector3(xPos, 0, zPos), Quaternion.identity);
        //previousX = tile.transform.position.x;
        //previousZ = tile.transform.position.z;
        previousX = xPos;
        previousZ = zPos;   

        print("X: " + previousX +"\n Z: " + previousZ);
        tileSpawner();
    }

    void Update()
    {
        
        
    }

    void tileSpawner()
    {
        //deciding position of the next tile
        xPos = Random.Range(5, 10);
        zPos = Random.Range(5,10);

        print("XPOS: " + xPos +"\n Zpos: " + zPos);
        
        //setting tranfrom of the next tile
        if (xPos >= zPos)
        {
             previousX += xPos ;
            previousZ += add;
            Instantiate(tile, new Vector3(previousX, 0, previousZ ), Quaternion.identity);
        }
        else
        {
            previousX += add;
            previousZ += zPos;
            Instantiate(tile, new Vector3( previousX, 0, previousZ ), Quaternion.identity);
        }

        
        
        print("X: " + previousX + "\n Z: " + previousZ);
    }
}
