using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowP2 : MonoBehaviour {
    private GameObject player2;
	// Use this for initialization
	void Start () {
        player2 = GameObject.FindGameObjectWithTag("Player2");
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = new Vector3(player2.transform.position.x - 0.4f, player2.transform.position.y + 2, 0);	
	}
}
