using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour {

    // Use this for initialization
    void Start () {
        InvokeRepeating("Blink", 0, 0.75f);
    }

    void Blink() {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {

    }
}
