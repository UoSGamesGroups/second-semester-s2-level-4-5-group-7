﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireRocketp2 : MonoBehaviour
{
    #region Global Variables
    public GameObject rocketPrefab;
    public GameObject rocketprefabv2;

    private GameObject CurrentRocket;
    private GameObject CurrentRocket2;

    public GameObject BlastRocketUI;
    public GameObject FragmentRocketUI;

    private const int Speed = 15;
    private bool fired = false;
    private bool fired2 = false;
    private float cooldown2 = 4;
    private float cooldown = 2;


    public Sprite frag;
    public Sprite blast;
    #region change these to alter cooldowns
    private float BlastCooldown = 2f;
    private float FragmentCooldown = 4f;
    #endregion
    #region Sprites for UI
    public Sprite Blast;
    public Sprite Frag;
    public Sprite BlastCD;
    public Sprite FragCD;
    #endregion
    #endregion

    private void Start()
    {
        cooldown = BlastCooldown;
        cooldown2 = FragmentCooldown;
    }
    // Update is called once per frame
    void Update()
    {
        //instantiate a rocket, set it as current and change fired to true
        if (Input.GetKeyDown(KeyCode.RightControl)&& !fired)
        {
            GameObject rocket = Instantiate(rocketPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            rocket.transform.rotation = gameObject.transform.rotation;
            rocket.GetComponent<SpriteRenderer>().sprite = blast;
            CurrentRocket = rocket;
            fired = true;
        }
        //instantiate a rocket, set it as current and change fired to true
        if (Input.GetKeyDown(KeyCode.RightShift) && !fired2)
        {
            GameObject rocket = Instantiate(rocketprefabv2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            rocket.transform.rotation = gameObject.transform.rotation;
            rocket.GetComponent<SpriteRenderer>().sprite = frag;
            CurrentRocket2 = rocket;
            fired2 = true;
        }
        //give the rockets their velocity
        if (CurrentRocket != null)
        {
            CurrentRocket.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
            CurrentRocket = null;
        }

        if (CurrentRocket2 != null)
        {
            CurrentRocket2.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
            CurrentRocket2 = null;
        }
        #region cooldown
        //change ui sprite to the on cooldown sprite and handle the cooldown
        if (fired)
        {
            BlastRocketUI.GetComponent<SpriteRenderer>().sprite = BlastCD;
            cooldown -= 1 * Time.deltaTime;
            if(cooldown <= 0)
            {
                fired = false;
                cooldown = BlastCooldown;
                BlastRocketUI.GetComponent<SpriteRenderer>().sprite = Blast;
            }
        }   
        //change ui sprite to the on cooldown sprite and handle the cooldown
       if (fired2)
        {
            FragmentRocketUI.GetComponent<SpriteRenderer>().sprite = FragCD;
            cooldown2 -= 1 * Time.deltaTime;
            if(cooldown2<= 0)
            {
                fired2 = false;
                cooldown2 = FragmentCooldown;
                FragmentRocketUI.GetComponent<SpriteRenderer>().sprite = Frag;
            }
        }
        #endregion cooldown
    }
}
