using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas pauseMeny;
    [SerializeField]
    bool gamePaused = false;
    public int i;

    public Camera slowMoCamera;

    public GameObject transitionInn = null;

    void Start()
    {
        

        pauseMeny.enabled = false;

        if(slowMoCamera != null) { 
        Camera.main.enabled = true;
        slowMoCamera.enabled = false;
        }
    }

    
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            i++;
        }

        switch (i)
        {
            case 1:
                gamePaused = true;
                PauseGame();
                break;
            case 2:
                gamePaused = false;
                PauseGame();
                i = 0;
                break;
        }
       
    }

    void PauseGame()
    {
        if(gamePaused)
        {
            Time.timeScale = 0;
            pauseMeny.enabled = true;
        } else
        {
            UnpauseGame();
        }     
    }
    void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseMeny.enabled = false;
    }
}
