using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour {
    void FixedUpdate () {
        if (Input.GetAxis("Cancel") > 0) {
            Debug.Log("Hey");
            SceneManager.LoadScene(0);
        }
    }
}
