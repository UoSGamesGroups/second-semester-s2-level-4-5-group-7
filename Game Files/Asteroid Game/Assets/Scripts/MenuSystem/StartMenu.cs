using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Button playButton;
    private void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(OnStartClick);
    }


    public void OnStartClick()
    {
        Debug.Log("Start Pressed");
        SceneManager.LoadScene("scene1");
    }
    public void OnInstructionClick()
    {
        Debug.Log("Instructions Pressed");
    }
}

