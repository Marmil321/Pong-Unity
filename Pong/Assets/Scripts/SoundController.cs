using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioSource goalSound;

    public Camera mainCamera;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            //goalSound.enabled = true;
            this.goalSound.Play();
            mainCamera.GetComponent<Animator>().SetTrigger("Shake");
        }
        else
        {
            this.hitSound.Play();
        }
    }

    private void Start()
    {
        //goalSound.enabled = false;
        //hitSound.enabled = false;
    }
}
