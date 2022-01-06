using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScripts : MonoBehaviour
{
    public float MovementSpeed;
    public float extraSpeed;
    public float maxSpeed;
    public float speed;
    float timeToWait;
    public float cooldown;

    public Transform ballStartPos;
    public TrailRenderer tr;

    public BossScript boss;
    public BoxCollider2D bossCollider;

    private float killRaduis = 0.4f;
    public bool death;
    public LayerMask bossLayermask;

    int hitcounter = 0;

    public bool bossBattle = false;
    private bool justStarted = true;

    void Start()
    {
        StartCoroutine(this.StartBall());
        Physics2D.IgnoreLayerCollision(11,11);
    }
    private void Update()
    {
        Detect();
    }

    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector2(ballStartPos.position.x, ballStartPos.position.y);
        } else
        {
            this.gameObject.transform.localPosition = new Vector2(ballStartPos.position.x, ballStartPos.position.y);
        }
    }
    public IEnumerator StartBall(bool isStartingplayer1 = true)
    {
        this.PositionBall(isStartingplayer1);
        //Debug.Log(isStartingplayer1);

        this.hitcounter = 0;
        
        if(justStarted)
        {
            timeToWait = cooldown;
            justStarted = false;
        } else
        {
            timeToWait = 1.5f;
        }

        yield return new WaitForSeconds(timeToWait);
        if (isStartingplayer1)
        {
            this.MoveBall(new Vector2(-1, 0));
            if(GameObject.Find("PlayerManager") != null)
            {
                if (FindObjectOfType<PlayerManager>().dead)
                {
                    GetComponent<Rigidbody2D>().gravityScale = 2;
                }
            }         
            
        } else if(!isStartingplayer1)
        {
            if(FindObjectOfType<PlayerManager>() != null)
            {
                if (FindObjectOfType<PlayerManager>().hp != 0)
                {
                    this.MoveBall(new Vector2(0, 0));
                }
            }else
            {
                this.MoveBall(new Vector2(1, 0));
            }
            
        }

        yield return new WaitForSeconds(4f);
        this.tr.enabled = true;
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        speed = this.MovementSpeed + this.hitcounter * this.extraSpeed;

        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = dir * speed;
    }
    public void IncreaseHitCounter()
    {
        if(this.hitcounter * this.extraSpeed <= this.maxSpeed)
        {
            this.hitcounter++;
        }
    }
    
    void Detect()
    {
        death = Physics2D.OverlapCircle(transform.position, killRaduis, bossLayermask);
        if(death)
        {
            //Debug.Log("hit!");
        }
    }
}
