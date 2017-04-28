using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class shipMovement : MonoBehaviour {
    private GameObject player1;
    private GameObject player2;

    private const int MaxSpeed = 5;

    private float p1currSpeed = 0;
    private float p2currSpeed = 0;
    private GameManager gm;



    // Use this for initialization
	void Start () {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
	}

    // Update is called once per frame
    void Update()
    {
        #region player 1 movement

        //add velocity forwards
        if (Input.GetKey(KeyCode.W))
        {
            //if w is pressed and curr speed is less than max speed, increase speed
            if (p1currSpeed <= MaxSpeed)
            {
                p1currSpeed += 1.5f * Time.deltaTime;
            }
        }
        if (!Input.GetKey(KeyCode.W))
        {
            //if w is not pressed, reduce speed slowly until the ship stops
            if (p1currSpeed > 0)
            {
                p1currSpeed -= 2f * Time.deltaTime;

            }
        }



        if (Input.GetKey(KeyCode.S))
        {
            //if s is pressed and current speed does not exceed -MaxSpeed, increase the backwards speed
            if (p1currSpeed >= -MaxSpeed)
            {
                p1currSpeed -= 1.5f * Time.deltaTime;
            }
        }
        if (!Input.GetKey(KeyCode.S))
        {
            if (p1currSpeed < 0)
            {
                p1currSpeed += 2f * Time.deltaTime;
            }
        }
        player1.transform.Translate(new Vector3(0, p1currSpeed, 0) * Time.deltaTime);

        if (!gm.Paused && Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.A)) { player1.transform.Rotate(new Vector3(0, 0, 1.5f) /** Time.deltaTime*/); }
            if (Input.GetKey(KeyCode.D)) { player1.transform.Rotate(new Vector3(0, 0, -1.5f)/* * Time.deltaTime*/); }
        }

        #endregion

        #region player 2 movement

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //if up arrow is pressed, increase acceleration forwards
            if (p2currSpeed <= MaxSpeed)
            {
                p2currSpeed += 1.5f * Time.deltaTime;
            }
        }
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            if (p2currSpeed > 0)
            {
                p2currSpeed -= 2f * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (p2currSpeed >= -MaxSpeed)
            {
                p2currSpeed -= 1.5f * Time.deltaTime;
            }
        }//add velocity backwards

        if (!Input.GetKey(KeyCode.DownArrow))
        {
            if (p2currSpeed < 0)
            {
                p2currSpeed += 2f * Time.deltaTime;
            }
        }
        player2.transform.Translate(new Vector3(0, p2currSpeed, 0) * Time.deltaTime);//add velocity forwards

        if (!gm.Paused && Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) { player2.transform.Rotate(new Vector3(0, 0, 1.5f) /** Time.deltaTime*/); }
            if (Input.GetKey(KeyCode.RightArrow)) { player2.transform.Rotate(new Vector3(0, 0, -1.5f)/* * Time.deltaTime*/); }
        }
        else
        {
            player1.transform.Rotate(new Vector3(0, 0, 0));
            player2.transform.Rotate(new Vector3(0, 0, 0));
            player2.transform.Translate(new Vector3(0, 0, 0));

        }
    }

        #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int timer = 50;
        if (collision.collider.tag == "asteroid")
        {
            while (timer > 0)
            {
                timer--;
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0,-100f) * Time.deltaTime);
            }
            timer = 50;
            if(gameObject.tag == "Player1")
            {
                p1currSpeed = 0;
            }
            else if(gameObject.tag == "Player2")
            {
                p2currSpeed = 0;
            }
        }
    }
}

