using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject shootingTip;
    public float shootSpeed = 300;
    public float seconds = 0;

    // Use this for initialization
    void Start () {
        seconds = 0;
    }

    // Update is called once per frame
    void Update () {
        if (Time.fixedTime - seconds >= 0.7) {
            if (Input.GetAxis("P1B") > 0) {
                ShootBullet();
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
