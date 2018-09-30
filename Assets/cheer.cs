using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheer : MonoBehaviour {
    private Animation animation;
	// Use this for initialization
	void Start () {
        animation = GetComponent<Animation>();
        animation.playAutomatically = false;
        foreach (AnimationState state in animation)
        {
            state.speed = 1 / Time.timeScale;
        }
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Random.value < 0.005f)
        {
            animation.Play();
        }
		
	}
}
