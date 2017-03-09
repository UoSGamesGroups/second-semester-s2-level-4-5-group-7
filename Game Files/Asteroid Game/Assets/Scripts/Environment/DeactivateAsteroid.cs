using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAsteroid : MonoBehaviour {

    private float maxBoundsX = 42f;
    private float maxBoundsY = 27f;

    private float counter = 100f;

    // Update is called once per frame
    void Update () {

        if(gameObject.transform.position.x < -maxBoundsX - 5 || gameObject.transform.position.x > maxBoundsX - 5)
        {
            counter++;
            if(counter > 100)
            {
                gameObject.SetActive(false);
                counter = 100f;
            }
        }

        else if (gameObject.transform.position.y < -maxBoundsY - 5 || gameObject.transform.position.y > maxBoundsY - 5)
        {
            counter++;
            if (counter > 100)
            {
                gameObject.SetActive(false);
                counter = 100f;
            }
        }


        else if(gameObject.transform.position.x < -maxBoundsX || gameObject.transform.position.x > maxBoundsX)
        {
            gameObject.SetActive(false);
        }
        else if (gameObject.transform.position.y < -maxBoundsY || gameObject.transform.position.y > maxBoundsY)
        {
            gameObject.SetActive(false);
        } 
	}
}
