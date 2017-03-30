using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpawn : MonoBehaviour {

    public GameObject BlackHoleObj;

   public float minUptime = 1f;
   public float maxUptime = 3f;
   public float minDowntime = 10f;
   public float maxDowntime = 15f;

    public float maxScale = 1;


    public float XPos = 19f;
    public float YPos = 19f;
  
    public BlackHole blackHoleScript;

    private void Start()
    {
        BlackHoleObj.SetActive(false);//disable it by default
        BlackHoleObj.transform.localScale = new Vector3(0, 0, 0);//make its scale 0
        BlackHoleObj.GetComponent<BlackHole>().enabled = false;//then disable the script for the black hole to suck in the objects
        StartCoroutine(BlackHoleDowntime());//then start the downtime coroutine 
        blackHoleScript = BlackHoleObj.GetComponent<BlackHole>();
    }

    //the time that the black hole appears on the screen
    IEnumerator BlackHoleUptime()
    {
        BlackHoleObj.GetComponent<BlackHole>().enabled = true;
        yield return new WaitForSeconds(Random.Range(minUptime, maxUptime));
        Debug.Log("reached uptime");
        BlackHoleObj.SetActive(false);
        BlackHoleObj.transform.localScale = new Vector3(0, 0, 0);
        BlackHoleObj.GetComponent<BlackHole>().enabled = false;
        StartCoroutine(BlackHoleDowntime());


    }
    //time between black hole disappearing and reappearing
    IEnumerator BlackHoleDowntime()
    {
        //wait for some time
        yield return new WaitForSeconds(Random.Range(minDowntime, maxDowntime));
        Debug.Log("reached downtime");
        //move the black hole
        BlackHoleObj.transform.position = new Vector2(Random.Range(-XPos,XPos),Random.Range(-YPos,YPos));
        //change its range
        blackHoleScript.range = Random.Range(blackHoleScript.minRange, blackHoleScript.maxRange);
        //change its intensity
        blackHoleScript.intensity = Random.Range(blackHoleScript.minIntensity, blackHoleScript.maxIntensity);
        BlackHoleObj.SetActive(true);
        while(BlackHoleObj.transform.localScale.x < maxScale)//while its scale is less than max, increase its scale
        {
            BlackHoleObj.transform.localScale += new Vector3(0.1f, 0.1f, 0);
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(BlackHoleUptime());
    }
}
