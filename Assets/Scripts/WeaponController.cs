using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private HingeJoint weapon;

    // Use this for initialization
    void Start () {
        weapon = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey("joystick button 5")) {
            weapon.useMotor = true;
        } else {
            weapon.useMotor = false;
        }
    }
}
