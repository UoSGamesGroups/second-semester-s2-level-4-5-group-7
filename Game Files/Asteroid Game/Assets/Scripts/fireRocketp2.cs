using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireRocketp2 : MonoBehaviour
{
    public GameObject rocketPrefabp2;
    private GameObject player2;
    private GameObject p2CurrentRocket;
    private const int Speed = 6;
    private bool fired = false;
    private float cooldown = 2;

    // Use this for initialization
    void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Player2");
        // currentRocket = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl)&& !fired)
        {
            GameObject rocket = Instantiate(rocketPrefabp2, new Vector3(player2.transform.position.x, player2.transform.position.y, player2.transform.position.z), Quaternion.identity) as GameObject;
            rocket.transform.rotation = player2.transform.rotation;
            p2CurrentRocket = rocket;
            fired = true;
        }
        if (p2CurrentRocket != null)
        {
            p2CurrentRocket.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
            p2CurrentRocket = null;
        }
        if(fired)
        {
            cooldown -= 1 * Time.deltaTime;
            if(cooldown <= 0)
            {
                fired = false;
                cooldown = 2f;
            }
        }
    }
}
