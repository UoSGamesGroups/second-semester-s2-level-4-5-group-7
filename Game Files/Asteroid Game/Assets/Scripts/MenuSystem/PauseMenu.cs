using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public Image pauseMenu;
    public Button Instructions;
    public Button Exit;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        gm.Paused = false;
        pauseMenu.enabled = false;
        Instructions.enabled = false;
        Exit.enabled = false;
    }

    public void OnPauseClick()
    {
        gm.Paused = !gm.Paused;
        if(gm.Paused)
        {
            Debug.Log("Pause Clicked");
            pauseMenu.enabled = true;
            Instructions.enabled = true;
            Exit.enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("Pause Clicked");
            pauseMenu.enabled = false;
            Instructions.enabled = false;
            Exit.enabled = false;
            Time.timeScale = 1;
        }
    }
    public void OnInstructionClick()
    {
        Debug.Log("Instruction Clicked");
        SceneManager.LoadScene("Instructions");
    }
    public void OnQuitClick()
    {
        Debug.Log("Quit Clicked");
        SceneManager.LoadScene("StartMenu");

    }
}
