﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    public float motorForce, brakeForce, spinFactor;
    public WheelCollider leftWheel, rightWheel, leftWheelFront, rightWheelFront;
    public int playerNumber = 1;

    private float seconds = 0;
    private bool shouldBlink = false;

    // Use this for initialization
    void Start () {
        seconds = 0;
        shouldBlink = false;
        InvokeRepeating("Blink", 0, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate () {
        float v = Input.GetAxis("P" + playerNumber + "Yaxis") * motorForce;
        float h = Input.GetAxis("P" + playerNumber + "Xaxis") * motorForce;

        if (Vector3.Dot(transform.up, Vector3.down) > 0) {
            if (Time.fixedTime - seconds >= 7) {
                shouldBlink = false;
                gameObject.transform.Rotate(180, 0, 0);
                gameObject.transform.position = new Vector3(180.0f, 5f, 0f);
            } else if (Time.fixedTime - seconds >= 4.5) {
                shouldBlink = true;
            }
        } else {
            seconds = Time.fixedTime;
        }

        if (v <= motorForce && v > motorForce - 1000) {
            leftWheel.motorTorque = -motorForce;
            leftWheelFront.motorTorque = -motorForce;
            rightWheel.motorTorque = -motorForce;
            rightWheelFront.motorTorque = -motorForce;

            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;
        } else if (v >= -motorForce && v < -motorForce + 1000) {
            leftWheel.motorTorque = motorForce;
            leftWheelFront.motorTorque = motorForce;
            rightWheel.motorTorque = motorForce;
            rightWheelFront.motorTorque = motorForce;

            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;
        } else if (h >= -motorForce && h < -motorForce + 1000) {
            leftWheel.motorTorque = motorForce * spinFactor;
            leftWheelFront.motorTorque = motorForce * spinFactor;
            rightWheel.motorTorque = -motorForce * spinFactor;
            rightWheelFront.motorTorque = -motorForce * spinFactor;

            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;
        } else if (h <= motorForce && h > motorForce - 1000) {
            leftWheel.motorTorque = -motorForce * spinFactor;
            leftWheelFront.motorTorque = -motorForce * spinFactor;
            rightWheel.motorTorque = motorForce * spinFactor;
            rightWheelFront.motorTorque = motorForce * spinFactor;

            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;
        } else {
            leftWheel.motorTorque = 0;
            leftWheelFront.motorTorque = 0;
            rightWheel.motorTorque = 0;
            rightWheelFront.motorTorque = 0;

            leftWheel.brakeTorque = brakeForce;
            rightWheel.brakeTorque = brakeForce;
            leftWheelFront.brakeTorque = brakeForce;
            rightWheelFront.brakeTorque = brakeForce;
        }

        if (Input.GetAxis("P" + playerNumber + "A") > 0) {
            leftWheel.brakeTorque = brakeForce;
            rightWheel.brakeTorque = brakeForce;
            leftWheelFront.brakeTorque = brakeForce;
            rightWheelFront.brakeTorque = brakeForce;
        } else {
            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;
        }
    }

    void Blink() {
        if (shouldBlink) {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        } else if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        }
    }
}