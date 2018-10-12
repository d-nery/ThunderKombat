using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour {


    void FixedUpdate () {
        if (Input.GetButtonDown("P1X") || Input.GetButtonDown("P2X")) {
            SceneManager.LoadScene(0);        
        }

        if (Input.GetButtonDown("P1A") || Input.GetButtonDown("P2A") || Input.GetButtonDown("P1B") || Input.GetButtonDown("P2B")) {
            SceneManager.LoadScene(2);
        }
    }
}
