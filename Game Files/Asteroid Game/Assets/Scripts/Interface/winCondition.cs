using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum Winner
{
    Default,
    Player1,
    Player2,
    Tie,
};

public class winCondition : MonoBehaviour {

    HealthController p1Health;
    HealthController p2Health;

    private GameObject player1;
    private GameObject player2;

    public Text winner;

    Winner victor;
    bool gameEnd;
    bool toStart;
    void Start ()
    {
        //assign player game objects
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        //get their instances of the HealthController script
        p1Health = player1.GetComponent<HealthController>();
        p2Health = player2.GetComponent<HealthController>();
	}
	
	void Update ()
    {
        //use an enum to define the winner 
        if (p1Health.Health <= 0) victor = Winner.Player2;
        else if (p2Health.Health <= 0) victor = Winner.Player1;
        else if (p1Health.Health <= 0 && p2Health.Health <= 0) victor = Winner.Tie;
 
        //use a switch statement to define the text for the winner based on the previous set of statements
        switch(victor)
        {
            case Winner.Default:
                winner.text = "";
                break;
            case Winner.Player1:
                gameEnd = true;
                winner.text = "Winner: Player 1";
               // Time.timeScale = 0;
                StartCoroutine(goToStart());
                break;
            case Winner.Player2:
                gameEnd = true;
                winner.text = "Winner: Player 2";
             //   Time.timeScale = 0;
                StartCoroutine(goToStart());

                break;
            case Winner.Tie:
                gameEnd = true;
                winner.text = "Tied Game";
             //   Time.timeScale = 0;
                StartCoroutine(goToStart());
                break;
        }
        if(gameEnd && !toStart)
        {
            StartCoroutine(goToStart());
            toStart = true;
        }
    }

    IEnumerator goToStart()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("StartMenu");

    }
}
