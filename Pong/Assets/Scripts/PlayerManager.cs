using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public CollisionContoller cc;
    public BallScripts bs;

    public GameObject transition;

    public int hp = 3;
    public bool dead= false;

    void Start()
    {
        cc.bossBattle = true;
        bs.bossBattle = true;
    }

    
    void Update()
    {
       switch(hp)
        {
            case 3:
                break;
            case 2:
                //play animation
                GameObject.Find("3HP").GetComponent<Animator>().SetTrigger("LoseHp");
                break;
            case 1:
                GameObject.Find("2HP").GetComponent<Animator>().SetTrigger("LoseHp");
                break;
            case 0:
                GameObject.Find("1HP").GetComponent<Animator>().SetTrigger("LoseHp");
                Invoke("Defeat", 2f);
                FindObjectOfType<ManageTransitions>().StartT();
                dead = true;
                break;
        } 
    }

    void Defeat()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}
