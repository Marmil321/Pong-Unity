using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public Button isMuted;
    public Button notMuted;

    public SaveManager saveManager;
    public SoundController sc;

    bool muted = false;

    void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
        
    }

    public void PrepQuitMenu()
    {
        FindObjectOfType<GameManager>().i++;
        StartCoroutine(QuitMenu());
        FindObjectOfType<ManageTransitions>().StartT();
        Debug.Log("Quit");
        Time.timeScale = 1f;
    }
    IEnumerator QuitMenu()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("MainMenu");
    }
    public void MuteSound()
    {
        Debug.Log("MUTE");
        //notMuted.gameObject.SetActive(false);
        //isMuted.gameObject.SetActive(false);

        if (muted)
        {
            muted = false;
            saveManager.UnMute();
        }
        else
        {
            muted = true;
            saveManager.Mute();
        }
    }
}
