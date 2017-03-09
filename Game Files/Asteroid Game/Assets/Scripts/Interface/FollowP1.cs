using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowP1 : MonoBehaviour {

    GameObject Player1;
	// Use this for initialization
	void Start () {
        Player1 = GameObject.FindGameObjectWithTag("Player1");
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = new Vector3(Player1.transform.position.x-0.6f,Player1.transform.position.y + 2.4f,0);
	}
}
