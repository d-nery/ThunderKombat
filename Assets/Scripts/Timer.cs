
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    // Use this for initializatio
    public Text timerText;
    private bool finished = false;
    public float maxTime = 6;
    private float startTime;
	void Start () {
        startTime = Time.fixedTime/3.0f;
	}

	// Update is called once per frame
	void Update () {

        if (finished)
        {
            return;
        }
        float t = maxTime -(Time.fixedTime/3.0f - startTime);

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = seconds;

        if (t < 0)
        {
            finished = true;
        }
	}
}
