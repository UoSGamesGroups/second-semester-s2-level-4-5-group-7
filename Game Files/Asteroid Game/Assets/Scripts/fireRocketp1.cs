﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireRocketp1 : MonoBehaviour {
    public GameObject rocketPrefabp1;
    private GameObject player1;
    private GameObject p1CurrentRocket;
    private const  int Speed = 6;

	// Use this for initialization
	void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1");
       // currentRocket = null;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject rocket = Instantiate(rocketPrefabp1, new Vector3(player1.transform.position.x, player1.transform.position.y, player1.transform.position.z), Quaternion.identity) as GameObject;
            rocket.transform.rotation = player1.transform.rotation;
            p1CurrentRocket = rocket;
        }
        if(p1CurrentRocket != null)
        {
            p1CurrentRocket.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
            p1CurrentRocket = null;
        }
	}
}