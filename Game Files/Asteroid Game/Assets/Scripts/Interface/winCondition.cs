using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                winner.text = "Winner: Player 1"; 
                break;
            case Winner.Player2:
                winner.text = "Winner: Player 2";
                break;
            case Winner.Tie:
                winner.text = "Tied Game";
                break;
        }
    }
}
