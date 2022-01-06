using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void PrepStartTheGame()
    {   
        Debug.Log("StartGame");
        StartCoroutine(StartTheGame());
        FindObjectOfType<ManageTransitions>().StartT();
    }
    IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("GameModes");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }
    public void PrepVsAi()
    {
        FindObjectOfType<ManageTransitions>().StartT();
        StartCoroutine(VsAi());
        Time.timeScale = 1f;
       
    }
    IEnumerator VsAi()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("PongGame");
    }
    public void PrepVsBoss()
    {
        FindObjectOfType<ManageTransitions>().StartT();
        StartCoroutine(VsBoss());
        Time.timeScale = 1f;  
    }
    IEnumerator VsBoss()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("BossFight");
    }
    public void PrepBackToMenu()
    {
        FindObjectOfType<ManageTransitions>().StartT();
        StartCoroutine(BackToMenu());
    }
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("MainMenu");
    }
        
}
