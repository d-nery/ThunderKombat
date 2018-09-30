
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    // Use this for initializatio
    public Text timerText;
    public bool finished = false;
    public float maxTime = 60;
    public float startTime;
    public AudioSource audioData;
    public bool isPlaying = false;
    void Start () {
        startTime = Time.fixedTime/3.0f;
        audioData = GetComponent<AudioSource>();
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

        if ( t < 10.9 && isPlaying == false)
        {
            isPlaying = true;
            audioData.Play();
        }

        if (t < 0)
        {
            finished = true;
        }
	}
}
