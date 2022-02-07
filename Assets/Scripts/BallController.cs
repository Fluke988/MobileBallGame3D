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
        xVal = Random.Range(-4.2f, 4.0f);
        zVal = Random.Range(-4.0f, -4.0f);
        transform.position = new Vector3(xVal, 3.25f, zVal);
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

        if(this.transform.position.y<-3.0f)
        {
            Debug.Log("Game Over!!!");
            Destroy(gameObject, 2f);
            GameController.Instance.SwitchScreen(EGameScreens.GAMEOVER);
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
        //if (other.transform.tag.Equals("ground"))
        //if(!other.transform.tag.Equals("ground"))
        //{
        //    Debug.Log("Game Over!!!");
        //    Destroy(gameObject, 2f);
        //    GameController.Instance.SwitchScreen(EGameScreens.GAMEOVER);
        //}
       
        //else
        if (other.transform.tag.Equals("speedboost"))
        {
            Debug.Log("Speeeeeed!!!");
            ballSpeed = ballSpeed + 2f;
        }

        else if (other.transform.tag.Equals("levelcomplete"))
        {
            Debug.Log("Level Complete!!!");
            Destroy(gameObject, 1f);
            GameController.Instance.SwitchScreen(EGameScreens.LEVELCOMPLETE);
        }

        else
        {
            
        }
    }
}