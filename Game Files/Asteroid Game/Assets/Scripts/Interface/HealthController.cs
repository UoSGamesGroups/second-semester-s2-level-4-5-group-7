using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public int Health;
   [SerializeField] private bool Immune;

	// Use this for initialization
	void Start ()
    {
        Health = 5;
        StartCoroutine(Immunity(3));
	}
	
	// Update is called once per frame
	void Update ()
    {
        	
        	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "asteroid" && !Immune)
        {
            Health --;
           StartCoroutine(Immunity(2));
            Debug.Log("Injured " + Health);
          
        }
    }
    private IEnumerator Immunity(int Seconds)
    {
        Immune = true;
        while(Seconds >= 0)
        {

          if(Seconds > 0)
            {
                yield return new WaitForSeconds(1);
                Seconds--;
            }
           
            if (Seconds <= 0)
            {
                Immune = false;
                break;
            }
        }
    }
}
