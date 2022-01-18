using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform square;
    [SerializeField] private int speed = 0;

    bool accelerometerEnabled = false;
    Gyroscope gyro = null;
    bool gyroEnabled = false;

    private void Start()
    {
        //Input.multiTouchEnabled = false;

    }

    bool IsAccelerometerSupported()
    {
        if(SystemInfo.supportsAccelerometer)
        {
            accelerometerEnabled = true;
            return true;
        }
        return false;
    }

    bool IsGyroSupported()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyroEnabled = true;
            return true;
        }
        return false;
    }

    void Update()
    {
        //if(Input.touchCount > 0)
        //{
        //    if(Input.touchCount == 1)
        //    {
        //        Touch t1 = Input.GetTouch(0);
        //        if(t1.phase == TouchPhase.Stationary)
        //        {
        //            Vector2 dir = Camera.main.ScreenToWorldPoint(t1.position);
        //            square.position = dir;
        //        }
        //        else if(t1.phase == TouchPhase.Moved)
        //        {
        //            Vector2 dir = Camera.main.ScreenToWorldPoint(t1.position);
        //            square.position = dir;
        //        }
        //        else if(t1.phase==TouchPhase.Ended)
        //        {
        //            square.transform.position = Vector2.zero;
        //        }
        //    }
            //else if (Input.touchCount == 2)
            //{
            //    Touch t1 = Input.GetTouch(0);
            //    Touch t2 = Input.GetTouch(1);
            //}
        //}
        
        if(accelerometerEnabled)
        {
            Debug.Log("Acc: " + Input.acceleration.x + " " + Input.acceleration.y + " " + Input.acceleration.z + " ");
            square.transform.Translate(new Vector2(Input.acceleration.x, 0) * speed * Time.deltaTime);
        }

        if(gyroEnabled)
        {
            Debug.Log("Gyro1: " + gyro.attitude);
            Debug.Log("Gyro2: " + gyro.attitude.eulerAngles);
            square.transform.rotation = gyro.attitude;
        }
    }
}
