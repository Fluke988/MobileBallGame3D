using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject tile;
    float xPos=0f, zPos=0f, previousX,previousZ;
    public float add;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void tileSpawner()
    {

        xPos = Random.Range(5, 10);
        zPos = Random.Range(5,10);

        print("XPOS: " + xPos +"\n Zpos: " + zPos);
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
