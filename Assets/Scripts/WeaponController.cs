using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private HingeJoint weapon;

    // Use this for initialization
    void Start () {
        weapon = GetComponent<HingeJoint>();
        weapon.useMotor = true;
    }

    // Update is called once per frame
    void Update () {
        JointMotor motor = weapon.motor;

        if (Input.GetAxis("P2B") > 0) {
            motor.targetVelocity = -1200;
        } else {
            motor.targetVelocity = 0;
        }

        weapon.motor = motor;
    }
}
