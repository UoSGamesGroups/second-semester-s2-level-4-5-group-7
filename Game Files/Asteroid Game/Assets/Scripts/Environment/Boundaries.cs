using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {

    public GameObject topWall;
    public GameObject botWall;
    public GameObject leftWall;
    public GameObject rightWall;
    public Camera cam;

	// Use this for initialization
	void Start () {
        float verticalHeight = cam.orthographicSize * 2;
        float horizontalWidth = verticalHeight * Screen.width / Screen.height;
        cam = Camera.main;
        topWall.transform.position = new Vector2(0, cam.transform.position.y + (verticalHeight / 2));
        botWall.transform.position = new Vector2(0,cam.transform.position.y - (verticalHeight/2));
        leftWall.transform.position = new Vector2(cam.transform.position.x - (horizontalWidth / 2),0);
        rightWall.transform.position = new Vector2(cam.transform.position.x + (horizontalWidth / 2), 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
