﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    void Update() {
        if (Input.GetAxis("Cancel") == 0 && Input.anyKey) {
            SceneManager.LoadScene(1);
        }
    }
}