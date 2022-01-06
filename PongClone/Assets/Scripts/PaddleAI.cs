using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public float movementSpeed;
    public float botLevel;

    public GameObject ball;

    private void FixedUpdate()
    {

        if(Mathf.Abs(this.transform.position.y - ball.transform.position.y) > botLevel){ 
            if(transform.position.y < ball.transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed;
                //Debug.Log("1");
            }else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed;
                //Debug.Log("2");
            }      
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0) * movementSpeed;
            //Debug.Log("3");
        }             
    }
}
