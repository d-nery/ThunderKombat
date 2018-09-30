using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject shootingTip;
    public float shootSpeed = 300;
    public float seconds = 0;

    private RobotBattery battery;

    // Use this for initialization
    void Start () {
        seconds = 0;
        battery = GetComponent<RobotBattery>();
    }

    void FixedUpdate () {
        if (Time.fixedTime - seconds >= 0.7) {
            if (!battery.Empty() && Input.GetAxis("P1B") > 0) {
                ShootBullet();
                battery.Shooting(true);
            } else {
                battery.Shooting(false);
            }
            seconds = Time.fixedTime;
        }
    }

    void ShootBullet() {
        GameObject tmpObj;

        tmpObj = Instantiate(bulletPrefab, shootingTip.transform.position + shootingTip.transform.forward, Quaternion.identity) as GameObject;

        Rigidbody projectile = tmpObj.GetComponent<Rigidbody>();

        projectile.velocity = -(shootingTip.transform.forward * shootSpeed);
    }
}
