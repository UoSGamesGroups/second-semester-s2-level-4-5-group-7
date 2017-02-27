using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlackHole : MonoBehaviour {

    private GameObject p1;
    private GameObject p2;
    private Rigidbody2D p1rb;
    private Rigidbody2D p2rb;
    private const int range = 4;
    private const float gravity = 100f;


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
        Vector2 thisPos = (gameObject.transform.position);

        //if the ship is within a certain area around the black hole, pull it into the centre
        if(p1Pos.x < thisPos.x + range && p1Pos.x > thisPos.x -range && p1Pos.y <thisPos.y + range && p1Pos.y > thisPos.y - range)
        {

            float xVel = 0.0f;
             float yVel = 0.0f;

            if (p1Pos.x < thisPos.x)
            {
                xVel = p1rb.velocity.x + gravity;
                //p1rb.velocity = new Vector2(p1rb.velocity.x + gravity, p1rb.velocity.y) * Time.deltaTime;
                Debug.Log("+x");
            }
            else if (p1Pos.x > thisPos.x)
            {
                xVel = p1rb.velocity.x - gravity;
                //p1rb.velocity = new Vector2(p1rb.velocity.x - gravity, p1rb.velocity.y) * Time.deltaTime;
                Debug.Log("-x");
            }
            if (p1Pos.y < thisPos.y)
            {
                yVel = p1rb.velocity.y + gravity;
                //p1rb.velocity = new Vector2(p1rb.velocity.x, p1rb.velocity.y + gravity) * Time.deltaTime;
                Debug.Log("+y");
            }
            else if (p1Pos.y > thisPos.y + range)
            {
                yVel = p1rb.velocity.y - gravity;
                //p1rb.velocity = new Vector2(p1rb.velocity.x, p1rb.velocity.y - gravity) * Time.deltaTime;
                Debug.Log("-y");
            }
            //    Debug.Log("here");
            p1rb.velocity = new Vector2(xVel, yVel) * Time.deltaTime;

        }
	}
}
