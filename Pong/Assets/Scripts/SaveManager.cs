using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static bool isMuted;
    public PauseMenuScript pm;

    void Awake()
    {
        pm = FindObjectOfType<PauseMenuScript>();
    }
    void FixedUpdate()
    {
        
    }
    
    void Update()
    {
        pm = FindObjectOfType<PauseMenuScript>();

        if (isMuted)
        {
            pm.notMuted.gameObject.SetActive(false);
            pm.isMuted.gameObject.SetActive(true);
            pm.sc.hitSound.volume = 0;
            pm.sc.goalSound.volume = 0;
        } else
        {
            pm.notMuted.gameObject.SetActive(true);
            pm.isMuted.gameObject.SetActive(false);
            pm.sc.hitSound.volume = 1;
            pm.sc.goalSound.volume = 1;
        }
    }
    public void UnMute()
    {
        isMuted = false;
    }
    public void Mute()
    {
        isMuted = true;
    }
}
