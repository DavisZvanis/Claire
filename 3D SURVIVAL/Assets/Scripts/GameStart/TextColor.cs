using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour {

    private float flickerTime;
    public Text text;
    public int counter = 1;

	// Use this for initialization
	void Start () {
        flickerTime = Random.value;
        StartCoroutine(Flickering(flickerTime));
    }

    private IEnumerator Flickering(float waitTime)
    {
        while (true)
        {
            if (counter == 1)
            {
                text.CrossFadeAlpha(0.4f, flickerTime, true);
                counter = 2;
            }
            else
            {
                text.CrossFadeAlpha(1, flickerTime, true);
                counter = 1;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
