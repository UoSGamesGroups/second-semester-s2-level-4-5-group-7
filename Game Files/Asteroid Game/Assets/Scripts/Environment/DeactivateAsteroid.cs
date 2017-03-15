using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAsteroid : MonoBehaviour {

    private float maxBoundsX = 42f;
    private float maxBoundsY = 27f;
    private float blackHoleDestructionRadius = 2f;
    private float counter = 100f;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
    }

  
    // Update is called once per frame
    void Update () {

        /*if the game object is out of bounds for a certain time, deactivate it */
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

        /*if the asteroid is outside of a larger bounds then deactivate it instantly */
        else if(gameObject.transform.position.x < -maxBoundsX || gameObject.transform.position.x > maxBoundsX)
        {
            gameObject.SetActive(false);
        }
        else if (gameObject.transform.position.y < -maxBoundsY || gameObject.transform.position.y > maxBoundsY)
        {
            gameObject.SetActive(false);
        }


        //black hole 
        //if (blackHole.activeSelf)

        if(gm.blackHole.activeSelf)
        {
            /*if the asteroid is within a certain radius of the black hole and it is active, deactivate it */
            if (gameObject.transform.position.x >= (gm.blackHole.transform.position.x - blackHoleDestructionRadius))
            {
                if (gameObject.transform.position.x <= (gm.blackHole.transform.position.x + blackHoleDestructionRadius))
                {
                    if (gameObject.transform.position.y >= (gm.blackHole.transform.position.y - blackHoleDestructionRadius))
                    {
                        if (gameObject.transform.position.y <= (gm.blackHole.transform.position.y + blackHoleDestructionRadius))
                        {
                            Debug.Log("Deactivating asteroid");
                            gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
