using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour {
    private GameObject player1;
    private GameObject player2;
    const int Speed = 10;
    // Use this for initialization
	void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
	}
	
	// Update is called once per frame
	void Update () {
        //player 1 movement
		if(Input.GetKey(KeyCode.W)) {player1.transform.Translate(new Vector3(0,Speed,0)*Time.deltaTime);}//add velocity forwards
        if (Input.GetKey(KeyCode.S)){ player1.transform.Translate(new Vector3(0, -Speed, 0) * Time.deltaTime); }//add velocity backwards
        if (Input.GetKey(KeyCode.A)) { player1.transform.Rotate(new Vector3(0,0,1.5f) /** Time.deltaTime*/); }
        if (Input.GetKey(KeyCode.D)) { player1.transform.Rotate(new Vector3(0,0,-1.5f)/* * Time.deltaTime*/); }

        //player 2 movement
        if (Input.GetKey(KeyCode.UpArrow)) { player2.transform.Translate(new Vector3(0, Speed, 0) * Time.deltaTime); }//add velocity forwards
        if (Input.GetKey(KeyCode.DownArrow)) { player2.transform.Translate(new Vector3(0, -Speed, 0) * Time.deltaTime); }//add velocity backwards
        if (Input.GetKey(KeyCode.LeftArrow)) { player2.transform.Rotate(new Vector3(0, 0, 1.5f) /** Time.deltaTime*/); }
        if (Input.GetKey(KeyCode.RightArrow)) { player2.transform.Rotate(new Vector3(0, 0, -1.5f)/* * Time.deltaTime*/); }

        else
        {
            player1.transform.Rotate(new Vector3(0, 0, 0));
            player1.transform.Translate(new Vector3(0, 0, 0));
            player2.transform.Rotate(new Vector3(0, 0, 0));
            player2.transform.Translate(new Vector3(0, 0, 0));

        }

    }
}
