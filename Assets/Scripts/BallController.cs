using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float ballSpeed;
    Rigidbody rb;
    bool gameStarted;
    //bool gameOver;
    float xVal, zVal;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameStarted = false;
        //gameOver = false;
    }
    
    void Start()
    {
        xVal = Random.Range(-4.5f, 4.5f);
        zVal = Random.Range(-9f, -1f);
        transform.position = new Vector3(xVal, 0, zVal);
        //rb.velocity = new Vector3(ballspeed,0,0);
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(ballSpeed, 0, 0);
                gameStarted = true;
                
            }
        }

        //Debug.DrawRay(transform.position, Vector3.down, Color.black);

        //if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        //{
        //    rb.velocity = new Vector3(0, -25f, 0);
        //    //gameOver = true;
            
        //}
        
        if (Input.GetMouseButtonDown(0) /*&& !gameOver*/)
        {
            ChangeBallDirection();
        }

        //if (gameOver == true)
        //{
        //    Destroy(gameObject, 3f);
        //}
    }

    void ChangeBallDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(ballSpeed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, ballSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("ground"))
        {
            Debug.Log("Game Over!!!");
            Destroy(gameObject, 2f);
            GameController.Instance.SwitchScreen(EGameScreens.GAMEOVER);
        }
    }
}