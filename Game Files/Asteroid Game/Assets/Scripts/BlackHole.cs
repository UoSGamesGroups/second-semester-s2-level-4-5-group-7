﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlackHole : MonoBehaviour {

    private GameObject p1;
    private GameObject p2;
    private Rigidbody2D p1rb;//player 1's rigidbody
    private Rigidbody2D p2rb;//player 2's ri
    private const int range = 4;
    private const float intensity = 100f;


	// Use this for initialization
	void Start () {
        p1 = GameObject.Find("player1");
        p2 = GameObject.Find("player2");
        p1rb = p1.GetComponent<Rigidbody2D>();
        p2rb = p2.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update () {
	    Vector2 p1Pos = (p1.transform.position);
        Vector2 p2Pos = (p2.transform.position);
        Vector2 thisPos = (gameObject.transform.position);

        #region player1
        //if the ship is within a certain area around the black hole, pull it into the centre
        if(p1Pos.x < thisPos.x + range && p1Pos.x > thisPos.x -range && p1Pos.y <thisPos.y + range && p1Pos.y > thisPos.y - range)
        {

            float xVel = 0.0f;
             float yVel = 0.0f;

            if (p1Pos.x < thisPos.x)
            {
                xVel = p1rb.velocity.x + intensity;
               
            }
            else if (p1Pos.x > thisPos.x)
            {
                xVel = p1rb.velocity.x - intensity;
               
            }
            if (p1Pos.y < thisPos.y)
            {
                yVel = p1rb.velocity.y + intensity;

            }
            else if (p1Pos.y > thisPos.y)
            {
                yVel = p1rb.velocity.y - intensity;
            }
            p1rb.velocity = new Vector2(xVel, yVel) * Time.deltaTime;

        }
        #endregion player1

        #region player2
        //if the ship is within a certain area, pull it into the centre
        if (p2Pos.x < thisPos.x + range && p2Pos.x > thisPos.x - range && p2Pos.y < thisPos.y + range && p2Pos.y > thisPos.y - range)
        {

            float xVel = 0.0f;
            float yVel = 0.0f;

            if (p2Pos.x < thisPos.x)
            {
                xVel = p2rb.velocity.x + intensity;
            }
            else if (p2Pos.x > thisPos.x)
            {
                xVel = p2rb.velocity.x - intensity;
            }
            if (p2Pos.y < thisPos.y)
            {
                yVel = p2rb.velocity.y + intensity;
            }
            else if (p2Pos.y > thisPos.y)
            {
                yVel = p2rb.velocity.y - intensity;
            }
            p2rb.velocity = new Vector2(xVel, yVel) * Time.deltaTime;

        }



            #endregion player2
        }
    }
