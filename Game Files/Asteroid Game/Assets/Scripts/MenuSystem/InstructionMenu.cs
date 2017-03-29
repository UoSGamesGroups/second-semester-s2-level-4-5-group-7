using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class InstructionMenu : MonoBehaviour {

	public void onClick()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
