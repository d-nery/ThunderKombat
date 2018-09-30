using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private HingeJoint weapon;

    public GameObject robot;

    private RobotBattery battery;

    // Use this for initialization
    void Start () {
        weapon = GetComponent<HingeJoint>();
        weapon.useMotor = true;
        battery = robot.GetComponent<RobotBattery>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        JointMotor motor = weapon.motor;

        if (!battery.Empty() && Input.GetAxis("P2B") > 0) {
            motor.targetVelocity = -1759;
            battery.WeaponOn(true);
        } else {
            motor.targetVelocity = 0;
            battery.WeaponOn(false);
        }

        weapon.motor = motor;
    }
}
