using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpawn : MonoBehaviour {

    public GameObject BlackHole;

   public float minUptime = 1f;
   public float maxUptime = 3f;
   public float minDowntime = 10f;
   public float maxDowntime = 15f;

    public float XPos = 19f;
    public float YPos = 19f;
  


    private void Start()
    {
        BlackHole.SetActive(false);
       StartCoroutine(BlackHoleDowntime());
    }

    //the time that the black hole appears on the screen
    IEnumerator BlackHoleUptime()
    {

        yield return new WaitForSeconds(Random.Range(minUptime, maxUptime));
        Debug.Log("reached uptime");
        BlackHole.SetActive(false);
        StartCoroutine(BlackHoleDowntime());


    }
    //time between black hole disappearing and reappearing
    IEnumerator BlackHoleDowntime()
    {
        yield return new WaitForSeconds(Random.Range(minDowntime, maxDowntime));
        Debug.Log("reached downtime");
        BlackHole.transform.position = new Vector2(Random.Range(-XPos,XPos),Random.Range(-YPos,YPos));
        BlackHole.SetActive(true);
        StartCoroutine(BlackHoleUptime());
    }
}
