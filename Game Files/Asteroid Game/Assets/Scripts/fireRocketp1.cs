using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireRocketp1 : MonoBehaviour {
    public GameObject rocketPrefab;
    public GameObject rocketPrefabv2;
    private GameObject p1CurrentRocket;
    private const  int Speed = 6;
    private float cooldown = 2;
    private bool fired2 = false;
    private float cooldown2 = 4f;
    private bool fired = false;

	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)& !fired)
        {
            GameObject rocket = Instantiate(rocketPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            rocket.transform.rotation = gameObject.transform.rotation;
            p1CurrentRocket = rocket;
            fired = true;
        }
        if (Input.GetKeyDown(KeyCode.E) & !fired2)
        {
            GameObject rocket = Instantiate(rocketPrefabv2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            rocket.transform.rotation = gameObject.transform.rotation;
            p1CurrentRocket = rocket;
            fired2 = true;
        }

        if (p1CurrentRocket != null)
        {
            p1CurrentRocket.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
            p1CurrentRocket = null;
        }
        if (fired)
        {
            cooldown -= 1 * Time.deltaTime;

            if (cooldown <= 0)
            {
                fired = false;
                cooldown = 2f;
            }
        }
        if(fired2)
        {
            cooldown2 -= 1 * Time.deltaTime;
            if(cooldown2 <= 0)
            {
                fired2 = false;
                cooldown2 = 4f;
            }
        }
    }
}
