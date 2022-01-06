using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilitys : MonoBehaviour
{
    public GameObject clone;
    int doAbility;

    public CollisionContoller cc;
    public SpriteRenderer sr;

    //clone abiliy
    [SerializeField]
    bool deleteClones;
    bool spawnClones;
    bool cloneActive;
    GameObject topClone;
    [SerializeField]
    GameObject bottomClone;
    public GameObject decayParticles;
    public GameObject cooldownBar;

    //GhostBall Ability
    public GameObject ball;
    [SerializeField]
    bool charging;
    Color defualtColor;
    bool ghostActive;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        defualtColor = GetComponent<SpriteRenderer>().color;
        cc = FindObjectOfType<CollisionContoller>();
        StartCoroutine(AbilityCooldowns(8.5f));
    }

    void Update()
    {
        ManageClones();
        Charge();
    }
    void CloneAbility()
    {
        spawnClones = true;
        cloneActive = true;

        if (spawnClones)
        {
            GameObject clone1 = Instantiate(clone, new Vector2(4.9f, 1.5f), Quaternion.identity);
            GameObject clone2 = Instantiate(clone, new Vector2(4.9f, -2.2f), Quaternion.identity);
            GameObject bar = Instantiate(cooldownBar);

            topClone = clone1;
            bottomClone = clone2;
            clone1 = null;
            clone2 = null;

            topClone.GetComponent<BoxCollider2D>().enabled = false;
            bottomClone.GetComponent<BoxCollider2D>().enabled = false;

            spawnClones = false;
        }

        StartCoroutine(DecayClone());
        print("delete");
    }
    void ManageClones()
    {
        if (deleteClones)
        {
            print("delete1");
            deleteClones = false;
            Destroy(topClone);
            topClone = null;
            Destroy(bottomClone);
            bottomClone = null;
        }

        if (cloneActive)
        {
            float topCloneMax = Mathf.Clamp(topClone.transform.position.y, 0.09f, 2.9f);
            float bottomCloneMax = Mathf.Clamp(bottomClone.transform.position.y, -5f, -1.33f);

            topClone.transform.position = new Vector2(topClone.transform.position.x, topCloneMax);
            bottomClone.transform.position = new Vector2(bottomClone.transform.position.x, bottomCloneMax);

            if (cc.lastHit && FindObjectOfType<BossClone>() != null)
            {
                topClone.GetComponent<BoxCollider2D>().enabled = true;
                bottomClone.GetComponent<BoxCollider2D>().enabled = true;
            }
            if (!cc.lastHit && FindObjectOfType<BossClone>() != null)
            {
                topClone.GetComponent<BoxCollider2D>().enabled = false;
                bottomClone.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
   
    }
    IEnumerator DecayClone()
    {
        yield return new WaitForSeconds(7.5f);
        GameObject particles1 = Instantiate(decayParticles,topClone.transform.position, Quaternion.identity);
        GameObject particles2 = Instantiate(decayParticles, bottomClone.transform.position, Quaternion.identity);
        print("delete2");
        deleteClones = true;
        cloneActive = false;
        yield return new WaitForSeconds(1f);
        Destroy(particles1);
        Destroy(particles2);

    }

    void ActivateGhostBall()
    {
        charging = true;
    }
    void GhostBall()
    {
        ghostActive = true;

        Vector2 ballPos = FindObjectOfType<BallScripts>().transform.position;
        BallScripts bs = FindObjectOfType<BallScripts>();
        GameObject circle = Instantiate(ball, ballPos, Quaternion.identity);

        circle.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
        bs.ballStartPos.position = ballPos;
        circle.GetComponent<BallScripts>().cooldown = 0;
        circle.GetComponent<BallScripts>().MovementSpeed = bs.speed;
        circle.GetComponent<BallScripts>().MoveBall(new Vector2(-1,Random.Range(-5,5)));
        circle.AddComponent<DestroyOnCollison>();

    }
    void Charge()
    {
        if(charging)
        {        
            if (cc.lastHit)
            {
                Color newColor = new Color(
                Random.value,
                Random.value,
                Random.value
                );

                sr.color = newColor;
            }
            if (!cc.lastHit)
            {
                charging = false;
                GhostBall();
            }
        }
        else
        {
            Color defualtCol = Color.red;
            sr.color = defualtCol;
        }
        if (ghostActive)
        {
            
        }

    }

    IEnumerator AbilityCooldowns(float Cooldown)
    {
        doAbility = 0;
        yield return new WaitForSeconds(Cooldown);
        SelectAbility();
    }
    void SelectAbility()
    {
        doAbility = Random.Range(0, 3);
        print(doAbility);
        doAbility = 2;

        switch (doAbility)
        {
            case 0:
                print("nothing");
                StartCoroutine(AbilityCooldowns(5));
                return;
            case 1:
                print("1");
                CloneAbility();
                StartCoroutine(AbilityCooldowns(8.5f));
                return;
            case 2:
                print("2");
                ActivateGhostBall(); //Error when active while win?
                StartCoroutine(AbilityCooldowns(8.5f));
                return;
            case 3:
                print("3");

                StartCoroutine(AbilityCooldowns(1));
                return;
            /*case 4:
                print("nothing");
                StartCoroutine(AbilityCooldowns(5));
                return;*/
            /*case 5:
                print("nothing");
                StartCoroutine(AbilityCooldowns(5));
                return;*/

        }
    }

}
