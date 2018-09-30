using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    public float motorForce, brakeForce, spinFactor;
    public WheelCollider leftWheel, rightWheel, leftWheelFront, rightWheelFront;
    public int playerNumber = 1;

    private RobotBattery battery;

    private RobotReset flip;
    private float seconds = 0;
    private bool resetting = false;

    // Use this for initialization
    public Vector3 initialPosition;
    public Quaternion initialRotation;

    // Use this for initialization
    void Start () {
        seconds = 0;
        resetting = false;
        battery = GetComponent<RobotBattery>();
        flip = GetComponent<RobotReset>();
        InvokeRepeating("Blink", 0, 0.5f);
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;

        GetComponent<Rigidbody>().maxAngularVelocity = 1.5f;
    }

    public void ResetPos() {
        gameObject.transform.position = initialPosition;
        gameObject.transform.rotation = initialRotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    private void ResetTransform() {
        if (Time.fixedTime - seconds >= 7) {
            resetting = false;
            gameObject.transform.position = initialPosition;
            gameObject.transform.rotation = initialRotation;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        } else if (Time.fixedTime - seconds >= 4.5) {
            resetting = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float v = Input.GetAxis("P" + playerNumber + "Yaxis") * motorForce;
        float h = Input.GetAxis("P" + playerNumber + "Xaxis") * motorForce;

        if (Vector3.Dot(transform.up, Vector3.down) > 0) {
            if (Input.GetAxis("P" + playerNumber + "X")) {
                flip.Pressing(true);
            }
            if (flip.Done()) {
                ResetTransform();
            }
        } else {
            resetting = false;
            seconds = Time.fixedTime;
        }

        if (battery.Empty()) {
            motorForce = 2700;
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

            battery.Driving(true);
        } else if (v >= -motorForce && v < -motorForce + 1000) {
            leftWheel.motorTorque = motorForce;
            leftWheelFront.motorTorque = motorForce;
            rightWheel.motorTorque = motorForce;
            rightWheelFront.motorTorque = motorForce;

            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;

            battery.Driving(true);
        } else if (h >= -motorForce && h < -motorForce + 1000) {
            leftWheel.motorTorque = motorForce * spinFactor;
            leftWheelFront.motorTorque = motorForce * spinFactor;
            rightWheel.motorTorque = -motorForce * spinFactor;
            rightWheelFront.motorTorque = -motorForce * spinFactor;

            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;

            battery.Driving(true);
        } else if (h <= motorForce && h > motorForce - 1000) {
            leftWheel.motorTorque = -motorForce * spinFactor;
            leftWheelFront.motorTorque = -motorForce * spinFactor;
            rightWheel.motorTorque = motorForce * spinFactor;
            rightWheelFront.motorTorque = motorForce * spinFactor;

            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;

            battery.Driving(true);
        } else {
            leftWheel.motorTorque = 0;
            leftWheelFront.motorTorque = 0;
            rightWheel.motorTorque = 0;
            rightWheelFront.motorTorque = 0;

            leftWheel.brakeTorque = brakeForce;
            rightWheel.brakeTorque = brakeForce;
            leftWheelFront.brakeTorque = brakeForce;
            rightWheelFront.brakeTorque = brakeForce;

            battery.Driving(false);
        }

        if (Input.GetAxis("P" + playerNumber + "A") > 0) {
            leftWheel.brakeTorque = brakeForce;
            rightWheel.brakeTorque = brakeForce;
            leftWheelFront.brakeTorque = brakeForce;
            rightWheelFront.brakeTorque = brakeForce;

            battery.Driving(false);
        } else {
            leftWheel.brakeTorque = 0;
            rightWheel.brakeTorque = 0;
            leftWheelFront.brakeTorque = 0;
            rightWheelFront.brakeTorque = 0;
        }
    }

    void Blink() {
        if (resetting) {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        } else if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        }
    }
}
