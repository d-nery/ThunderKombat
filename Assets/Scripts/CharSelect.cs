using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour {

    public AudioSource SelectAudio;
    void FixedUpdate () {
        if (Input.GetAxis("P1B") > 0) {
            SceneManager.LoadScene(0);
            SelectAudio.Play();
        }

        if (Input.GetAxis("P1A") > 0) {
            SceneManager.LoadScene(2);
            SelectAudio.Play();
        }
    }
}
