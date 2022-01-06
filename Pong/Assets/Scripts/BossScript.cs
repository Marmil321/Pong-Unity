using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public BallScripts ball;
    public Camera breakCam;
    public SoundController sc;
    public CollisionContoller cc;
    public BoxCollider2D bossCollider;

    public GameObject deathParticles;
    public GameObject ragdoll;

    private bool leathal = false;

    void Update()
    {

        if(ball.death && ball.speed >= 25 && leathal)
        {
            bossCollider.enabled = false;
            Debug.Log("hit!");
            Break();
        }

        if (ball.transform.position.x >= 2.35f && ball.speed >= 25 && cc.lastHit)
        {
            PrepareBreak();
            cc.lastHit = false;
        }
    }


    public void Break()
    {
        Time.timeScale = 0.05f;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<PaddleAI>().enabled = false;
        this.sc.goalSound.Play();

        var deleteObj = GetComponentInParent<SpriteRenderer>();
        Destroy(deleteObj);

        Vector2 offset = new Vector2(transform.position.x, transform.position.y - 0.5f);
        GameObject bossRagdoll = Instantiate(ragdoll, offset, Quaternion.identity) as GameObject;
        GameObject death = Instantiate(deathParticles, transform.position, Quaternion.identity) as GameObject;

        StartCoroutine(VictoryScreen());
    }

    public void PrepareBreak()
    {
        Time.timeScale = .15f;
        Time.fixedDeltaTime = .001f;
        //Camera.main.enabled = false;
        breakCam.enabled = true;
        sc.goalSound.pitch = 0.5f;
        sc.hitSound.pitch = Time.timeScale;
        sc.hitSound.Play();
        leathal = true;
    }

    IEnumerator VictoryScreen()
    {
        yield return new WaitForSeconds(0.20f);
        FindObjectOfType<ManageTransitions>().StartT();
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene("VictoryScene");
    }

}
