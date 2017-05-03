using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    private const int Speed = 20;
    private bool fired = false;
    private bool fired2 = false;
    private float cooldown2 = 4;
    private float cooldown = 2;

    private GameManager gm;

    public Sprite frag;
    public Sprite blast;
    #region change these to alter cooldowns
    private float BlastCooldown = 2f;
    private float FragmentCooldown = 4f;
    #endregion
    #region Sprites for UI
    public Image Blast;
    public Image Frag;
    #endregion
    #endregion

    private void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        cooldown = BlastCooldown;
        cooldown2 = FragmentCooldown;
    }
    // Update is called once per frame
    void Update()
    {
        if (!gm.Paused)
        {
            //instantiate a rocket, set it as current and change fired to true
            if (Input.GetKeyDown(KeyCode.RightControl) && !fired)
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
        }
        #region cooldown
        if (fired)
        {
            //if the cooldown is max, set fill amount to 0
            if (cooldown == BlastCooldown)
                Blast.fillAmount = 0;

            //reduce cooldown by 1 per second and divide 1 (max fill amount) by the number of seconds
            cooldown -= 1 * Time.deltaTime;
            Blast.fillAmount += (1/BlastCooldown) * Time.deltaTime;
            //if cooldown is 0, reset the cooldown and allow the player to fire

            if (cooldown <= 0)
            {
                fired = false;
                cooldown = BlastCooldown;
            }
        }   
       if (fired2)
        {
            //if cooldown is max, set fill amount to 0
            if (cooldown2 == FragmentCooldown)
                Frag.fillAmount = 0;

            //reduce cooldown by 1 per second and divide 1(max fill amount) by the number of seconds
            cooldown2 -= 1 * Time.deltaTime;
            Frag.fillAmount += (1/FragmentCooldown) * Time.deltaTime;
            //if cooldown is 0, reset the cooldown and allow the player to fire
            if(cooldown2<= 0)
            {
                fired2 = false;
                cooldown2 = FragmentCooldown;
            }
        }
        #endregion cooldown
    }
}
