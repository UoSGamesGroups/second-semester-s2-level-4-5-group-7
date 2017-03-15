using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class fireRocketp1 : MonoBehaviour {
    #region global variables
    public GameObject rocketPrefab;
    public GameObject rocketPrefabv2;
    public GameObject BlastRocketUI;
    public GameObject FragmentRocketUI;
    private GameObject CurrentRocket1;
    private GameObject CurrentRocket2;


    private const  int Speed = 15;
    private float cooldown;
    private bool fired2 = false;
    private float cooldown2;
    private bool fired = false;


    public Sprite frag;
    public Sprite blast;

    #region Change these to alter the cooldowns
    private float BlastCooldown = 2f;
    private float FragmentCooldown = 4f;
    #endregion
    #region Sprites for UI
    public Image Blast;
    public Image Frag;
   // public Sprite BlastCD;
   // public Sprite FragCD;
    #endregion
    #endregion

    private void Start()
    {
        cooldown = BlastCooldown;
        cooldown2 = FragmentCooldown;
    }

    // Update is called once per frame
    void Update () {
        //instantiate a rocket, set it as current and change fired to true
		if(Input.GetKeyDown(KeyCode.Q)& !fired)
        {
            GameObject rocket = Instantiate(rocketPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            rocket.transform.rotation = gameObject.transform.rotation;
            rocket.GetComponent<SpriteRenderer>().sprite = blast;
            CurrentRocket1 = rocket;
            fired = true;
        }
        //instantiate a rocket, set it as current and change fired to true 
        if (Input.GetKeyDown(KeyCode.E) & !fired2)
        {
            GameObject rocket = Instantiate(rocketPrefabv2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
            rocket.transform.rotation = gameObject.transform.rotation;
            rocket.GetComponent<SpriteRenderer>().sprite = frag;
            CurrentRocket2 = rocket;
            fired2 = true;
        }
        //give the rockets their velocity
        if (CurrentRocket1 != null)
        {
            CurrentRocket1.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
            CurrentRocket1 = null;
        }
        if(CurrentRocket2 != null)
        {
            CurrentRocket2.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
            CurrentRocket2 = null;
        }


        #region Cooldown
        //change ui sprite to the on cooldown sprite and handle the cooldown
        if (fired)
        {
            //if cooldown is max, set fillamount to 0
            if(cooldown == BlastCooldown)
            Blast.fillAmount = 0;
            //reduce cooldown by 1 per second and increase fill amount by 1(max fillamount) divided by the number of seconds
            cooldown -= 1f * Time.deltaTime;
            Blast.fillAmount += (1/BlastCooldown) * Time.deltaTime;
            //if cooldown is 0, reset the cooldown and let the player fire
            if (cooldown <= 0)
            {
                fired = false;
                cooldown = BlastCooldown;
            }
        }
        //change ui sprite to the cooldown sprite and handle the cooldown
        if(fired2)
        {
            if (cooldown2 == FragmentCooldown)
                Frag.fillAmount = 0;

            //reduce the cooldown by 1 per second, and increase the fill amount by 0.25 per second
            cooldown2 -= 1 * Time.deltaTime;
            Frag.fillAmount += (1/FragmentCooldown) * Time.deltaTime;
            //if cooldown is 0, reset cooldown and allow the player to fire
            if(cooldown2 <= 0)
            {
                fired2 = false;
                cooldown2 = FragmentCooldown;
            }
        }
        #endregion
    }
}
