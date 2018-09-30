using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDestroy : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Invoke("noPanel", 5f);
    }

    void noPanel() {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {

    }
}
