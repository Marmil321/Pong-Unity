using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadyScript : MonoBehaviour
{
    bool ready;
    bool once;

    public GameObject[] check;
    public Canvas canvas;

    public TMP_Text text;

    private void Update()
    {
        if (!ready)
        {
            Time.timeScale = 0;
        }
        if(ready && !once)
        {
            StartCoroutine(Timer());
            once = true;       
        }

        if(check[0].activeInHierarchy && check[1].activeInHierarchy)
        {
            ready = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            check[0].SetActive(true); 
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            check[1].SetActive(true);
        }
    }
    IEnumerator Timer()
    {
        text.text = "3";
        text.gameObject.SetActive(true);
        text.GetComponent<Animator>().Play("Countdown");
        yield return new WaitForSecondsRealtime(1);
        text.text = "2";
        yield return new WaitForSecondsRealtime(1);
        text.text = "1";
        yield return new WaitForSecondsRealtime(1);
        text.text = "0";
        yield return new WaitForSecondsRealtime(.5f);
        Time.timeScale = 1;
        Destroy(canvas.gameObject);
        Destroy(this);
    }
}
