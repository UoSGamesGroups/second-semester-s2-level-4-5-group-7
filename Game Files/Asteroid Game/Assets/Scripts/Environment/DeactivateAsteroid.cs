using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAsteroid : MonoBehaviour {

    private float maxBoundsX = 37f;
    private float maxBoundsY = 23f;
	
    // Update is called once per frame
    void Update () {
		if(gameObject.transform.position.x < -maxBoundsX || gameObject.transform.position.x > maxBoundsX)
        {
            gameObject.SetActive(false);
        }
        else if (gameObject.transform.position.y < -maxBoundsY || gameObject.transform.position.y > maxBoundsY)
        {
            gameObject.SetActive(false);
        } 
	}
}
