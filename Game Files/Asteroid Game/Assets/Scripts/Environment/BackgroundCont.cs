using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCont : MonoBehaviour {

    public Sprite bg1;
    public Sprite bg2;

    public Animation anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        int randomBg = Random.Range(0, 2);

        if(randomBg == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bg1;
            StartCoroutine(playAnim());
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bg2;
        }
	}
    private IEnumerator repeatCoroutine(int Max_seconds,int Min_seconds)
    {
        yield return new WaitForSeconds(Random.Range(Min_seconds,Max_seconds));
        StartCoroutine(playAnim());
    }
    private IEnumerator playAnim()
    {
        anim.Play("Planet");
        yield return new WaitForSeconds(2);
        anim.Stop("Planet");
        repeatCoroutine(15,30);
    }

}
