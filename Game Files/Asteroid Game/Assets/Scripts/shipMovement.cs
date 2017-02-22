using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class shipMovement : MonoBehaviour {
    private GameObject player1;
    private GameObject player2;
    const int MaxSpeed = 5;
    int Speed = 5;
   [SerializeField] private float p1currSpeed = 0;
   [SerializeField] private float p2currSpeed = 0;




    // Use this for initialization
	void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
	}
	
	// Update is called once per frame
	void Update () {

        #region player 1 movement
        //add velocity forwards
        if (Input.GetKey(KeyCode.W))
        {
            //if w is pressed and curr speed is less than max speed, increase speed
            if (p1currSpeed <= MaxSpeed)
            {
                p1currSpeed += 1f * Time.deltaTime;
            }
            //apply movement based on the speed
            player1.transform.Translate(new Vector3(0,p1currSpeed,0)*Time.deltaTime);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            //if w is not pressed, reduce speed slowly until the ship stops
            if (p1currSpeed > 0)
            {
                p1currSpeed -= 2f * Time.deltaTime;
             
            }
            player1.transform.Translate(new Vector3(0, p1currSpeed, 0) * Time.deltaTime);
        }



        if (Input.GetKey(KeyCode.S))
        {
            //if s is pressed and current speed does not exceed -MaxSpeed, increase the backwards speed
            if(p1currSpeed >= -MaxSpeed)
            {
                p1currSpeed -= 1f * Time.deltaTime;
            }
            //apply movement based on speed
            player1.transform.Translate(new Vector3(0, p1currSpeed, 0) * Time.deltaTime);//add velocity backwards
        }
        if(!Input.GetKey(KeyCode.S))
        {
            if(p1currSpeed < 0)
            {
                p1currSpeed += 2f * Time.deltaTime;
            }
        }


        if (Input.GetKey(KeyCode.A)) { player1.transform.Rotate(new Vector3(0,0,1.5f) /** Time.deltaTime*/); }
        if (Input.GetKey(KeyCode.D)) { player1.transform.Rotate(new Vector3(0,0,-1.5f)/* * Time.deltaTime*/); }
        #endregion


        #region player 2 movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //if up arrow is pressed, increase acceleration forwards
            if (p2currSpeed <= MaxSpeed)
            {
                p2currSpeed += 1f * Time.deltaTime;
            }
            player2.transform.Translate(new Vector3(0, p2currSpeed, 0) * Time.deltaTime);//add velocity forwards
        }
        if(!Input.GetKey(KeyCode.UpArrow))
        {
            if (p2currSpeed > 0)
            {
                p2currSpeed -= 2f * Time.deltaTime;
            }
            player2.transform.Translate(new Vector3(0, p2currSpeed, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (p2currSpeed >= -MaxSpeed)
            {
                p2currSpeed -= 1f * Time.deltaTime;
            }
                player2.transform.Translate(new Vector3(0, p2currSpeed, 0) * Time.deltaTime);
        }//add velocity backwards

        if (!Input.GetKey(KeyCode.DownArrow))
        {
            if (p2currSpeed < 0)
            {
                p2currSpeed += 2f * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)) { player2.transform.Rotate(new Vector3(0, 0, 1.5f) /** Time.deltaTime*/); }
        if (Input.GetKey(KeyCode.RightArrow)) { player2.transform.Rotate(new Vector3(0, 0, -1.5f)/* * Time.deltaTime*/); }

        else
        {
            player1.transform.Rotate(new Vector3(0, 0, 0));        
            player2.transform.Rotate(new Vector3(0, 0, 0));
            player2.transform.Translate(new Vector3(0, 0, 0));

        }
        #endregion

    }
}
