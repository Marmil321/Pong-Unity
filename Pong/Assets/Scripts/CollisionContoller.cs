using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionContoller : MonoBehaviour
{
    public BallScripts ballMovement;

    public ScoreContoller scoreContoller;

    public GameObject goalParticles;
    public GameObject hitParticles;

    public bool lastHit;
    public GameManager gm;

    public bool bossBattle = false;

    void BounceFromPaddle(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 paddlePosition = c.gameObject.transform.position;

        float paddleHeight = c.collider.bounds.size.y;

        float x;
        if(c.gameObject.name == "Paddle1")
        {
            x = 1;
        } else
        {
            x = -1; 
        }

        float y = (ballPosition.y - paddlePosition.y) / paddleHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            GameObject particles = Instantiate(goalParticles, transform.position, Quaternion.identity) as GameObject;
            Destroy(particles, 2f);
        } else
        {
            GameObject hitParticle = Instantiate(hitParticles, transform.position, Quaternion.identity) as GameObject;
            Destroy(hitParticle, 1f);
        }
        if (collision.gameObject.name == "Boss")
        {
            this.BounceFromPaddle(collision);
            lastHit = false;
        }
        if (collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            this.BounceFromPaddle(collision);
            lastHit = true; 

        } else if (collision.gameObject.name == "WallLeft") 
        {
            if(!bossBattle)
            {
                this.scoreContoller.GoalPlayer2();
            } else if(bossBattle)
            {
                FindObjectOfType<PlayerManager>().hp--;
            }
            Debug.Log("player2 score");
            StartCoroutine(this.ballMovement.StartBall(true));
            this.ballMovement.tr.enabled = false;
            lastHit = false;
            //Time.timeScale = 1f;
            //gm.slowMoCamera.enabled = false;
            //Time.fixedDeltaTime = 1f;

        }
        else if (collision.gameObject.name == "WallRight" && !bossBattle)
        {
            Debug.Log("player1 score");
            this.scoreContoller.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false)) ;
            this.ballMovement.tr.enabled = false;
            lastHit = false;
            //Time.timeScale = 1f;
            //gm.slowMoCamera.enabled = false;
            //Time.fixedDeltaTime = 1f;
        }
    }
}
