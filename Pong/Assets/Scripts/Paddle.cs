using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        float verMove = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(0, verMove) * speed * Time.deltaTime ;

        if(transform.position.y < -3.65)
        {
            transform.position = new Vector2(transform.position.x, -3.65f);
        } else if (transform.position.y > 2.67)
        {
            transform.position = new Vector2(transform.position.x, 2.67f);
        }
    }
}
