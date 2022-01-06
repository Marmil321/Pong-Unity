using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    public float degree;
    public float ballSpeed;

    float maxDegree = -75;
    float minDegree = 75;

    float maxSpeed = 25;
    [SerializeField]
    float speed;

    public BallScripts bs;

    private void Start()
    {
        speed = 1;

        if (GameObject.Find("Ball"))
        {
            bs = GameObject.Find("Ball").GetComponent<BallScripts>();
        }else
        {
            bs = null;
        }
    }
    void Update()
    {
        if(bs != null)
        {
            speed = bs.speed;
        }

        transform.eulerAngles = new Vector3(0, 0, Angle());

        if (speed > maxSpeed) speed = maxSpeed;
    }
    //convert speed to degrees
    public float Angle()
    {
        float totalNum = minDegree - maxDegree;

        float speedNormalized = speed / maxSpeed;

        return minDegree - speedNormalized * totalNum;
    } 
}
