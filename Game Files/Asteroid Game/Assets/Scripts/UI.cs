using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class UI : MonoBehaviour {

    #region Health pips
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;
    public GameObject HP5;

    public Sprite S_HP;
    #endregion


    private HealthController healthControl;
 
    // Use this for initialization
    void Start ()
    {
        healthControl = gameObject.GetComponent<HealthController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //when health is full, set all sprites 
        if (healthControl.Health == 5)
        {
           HP5.GetComponent<SpriteRenderer>().sprite = S_HP;
           HP4.GetComponent<SpriteRenderer>().sprite = S_HP;
           HP3.GetComponent<SpriteRenderer>().sprite = S_HP;
           HP2.GetComponent<SpriteRenderer>().sprite = S_HP;
           HP1.GetComponent<SpriteRenderer>().sprite = S_HP;
        }
        //when health is 4, show only 4 sprites
        else if (healthControl.Health == 4) HP5.GetComponent<SpriteRenderer>().sprite = null;
        //when health is 3, show only 3 sprites 
        else if (healthControl.Health == 3) HP4.GetComponent<SpriteRenderer>().sprite = null;
        //when health is 2, show only 2 sprites
        else if (healthControl.Health == 2) HP3.GetComponent<SpriteRenderer>().sprite = null;
        //when health is 1, show only 1 sprites
        else if (healthControl.Health == 1) HP2.GetComponent<SpriteRenderer>().sprite = null;
        //when health is 0, show no sprites
        else if (healthControl.Health == 0) HP1.GetComponent<SpriteRenderer>().sprite = null;

    }
}
