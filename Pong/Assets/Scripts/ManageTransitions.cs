using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageTransitions : MonoBehaviour
{
    public GameObject transitionInn;

    private void Start()
    {
        transitionInn.GetComponent<Animator>().SetTrigger("awake");
        Time.timeScale = 1;

    }
    public void StartT()
    {
       
        StartCoroutine(TransitionInn());    
   
    }


    IEnumerator TransitionInn()
    {
        transitionInn.GetComponent<Animator>().SetTrigger("out");
        yield return new WaitForSeconds(1.1f);

    }
    IEnumerator reset()
    {
        yield return new WaitForSeconds(1f);

    }
}
