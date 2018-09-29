using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCarro : MonoBehaviour {

    public float MotorForce, SteerForce, BrakeForce, SpinFactor;
    public WheelCollider Left_Wheel, Right_Wheel, F_Left_Wheel, F_Right_Wheel;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate () {

        float v = Input.GetAxis("Vertical") * MotorForce;
        float h = Input.GetAxis("Horizontal") * MotorForce;

        print("v = " + v + "h = " + h);
        //print(v);
        //print(h);

        //Left_Wheel.motorTorque = - (v + h);
        //F_Left_Wheel.motorTorque = - (v + h);

        //Right_Wheel.motorTorque = -(v - h); ;
        //F_Right_Wheel.motorTorque = -(v - h);

        if ( v <= MotorForce && v > MotorForce - 1000)
        {
            Left_Wheel.motorTorque = -MotorForce;
            F_Left_Wheel.motorTorque = -MotorForce;
            Right_Wheel.motorTorque = -MotorForce;
            F_Right_Wheel.motorTorque = -MotorForce;

            Left_Wheel.brakeTorque = 0;
            Right_Wheel.brakeTorque = 0;
            F_Left_Wheel.brakeTorque = 0;
            F_Right_Wheel.brakeTorque = 0;

        } else if (v >= -MotorForce && v < -MotorForce + 1000)
        {
            Left_Wheel.motorTorque = MotorForce;
            F_Left_Wheel.motorTorque = MotorForce;
            Right_Wheel.motorTorque = MotorForce;
            F_Right_Wheel.motorTorque = MotorForce;

            Left_Wheel.brakeTorque = 0;
            Right_Wheel.brakeTorque = 0;
            F_Left_Wheel.brakeTorque = 0;
            F_Right_Wheel.brakeTorque = 0;

        } else if (h >= -MotorForce && h < -MotorForce + 1000)
        {

            Left_Wheel.motorTorque = MotorForce * SpinFactor;
            F_Left_Wheel.motorTorque = MotorForce * SpinFactor;
            Right_Wheel.motorTorque = -MotorForce * SpinFactor;
            F_Right_Wheel.motorTorque = -MotorForce * SpinFactor;

            Left_Wheel.brakeTorque = 0;
            Right_Wheel.brakeTorque = 0;
            F_Left_Wheel.brakeTorque = 0;
            F_Right_Wheel.brakeTorque = 0;

        } else if (h <= MotorForce && h > MotorForce - 1000)
        {

            Left_Wheel.motorTorque = -MotorForce * SpinFactor;
            F_Left_Wheel.motorTorque = -MotorForce * SpinFactor;
            Right_Wheel.motorTorque = MotorForce * SpinFactor;
            F_Right_Wheel.motorTorque = MotorForce * SpinFactor;

            Left_Wheel.brakeTorque = 0;
            Right_Wheel.brakeTorque = 0;
            F_Left_Wheel.brakeTorque = 0;
            F_Right_Wheel.brakeTorque = 0;


        }

        else
        {
            Left_Wheel.motorTorque = 0;
            F_Left_Wheel.motorTorque = 0;
            Right_Wheel.motorTorque = 0;
            F_Right_Wheel.motorTorque = 0;

            Left_Wheel.brakeTorque = BrakeForce;
            Right_Wheel.brakeTorque = BrakeForce;
            F_Left_Wheel.brakeTorque = BrakeForce;
            F_Right_Wheel.brakeTorque = BrakeForce;

        }

        if (Input.GetKey("joystick button 0"))
        {
            Left_Wheel.brakeTorque = BrakeForce;
            Right_Wheel.brakeTorque = BrakeForce;
            F_Left_Wheel.brakeTorque = BrakeForce;
            F_Right_Wheel.brakeTorque = BrakeForce;

        }
        else if (Input.GetKeyUp("joystick button 0"))
        {
            Left_Wheel.brakeTorque = 0;
            Right_Wheel.brakeTorque = 0;
            F_Left_Wheel.brakeTorque = 0;
            F_Right_Wheel.brakeTorque = 0;

        }


    }
}
