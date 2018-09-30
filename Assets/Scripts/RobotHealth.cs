using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RobotHealth : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    public int bulletDamage = 10;
    public int activeWeaponDamage = 20;
    public int disabledWeaponDamage = 1;
    public int wedgeDamage = 15;
    public Slider healthSlider;

    private HingeJoint hjoint;

    void Start () {
        Debug.Log("ReStarting Health Script");
        currentHealth = startingHealth;
    }

    void Update() {
        Debug.Log(currentHealth);
    }

    public void OnCollisionEnter(Collision col) {
        Debug.Log("Collision detected: " + col.gameObject.tag);

        if (col.gameObject.tag == "Bullet") {
            Debug.Log("Collision of a Bullet.");
            TakeDamage(bulletDamage);
        } else if (col.gameObject.tag == "ActiveWeapon") {
            Debug.Log("Collision of an Active Weapon.");
            hjoint = col.gameObject.GetComponent<HingeJoint>();

            if (hjoint.velocity > Mathf.Abs(500)) {
                TakeDamage(activeWeaponDamage);
            } else {
                TakeDamage(disabledWeaponDamage);
            }
        } else if (col.gameObject.tag == "Wedge") {
            Debug.Log("Collision of a Wedge.");
            TakeDamage(wedgeDamage);
        }
    }

    public void OnTriggerEnter(Collider col) {
        Debug.Log("Trigger detected: " + col.gameObject.tag);

        if (col.gameObject.tag == "Bullet") {
            Debug.Log("Collision of a Bullet.");
            TakeDamage(bulletDamage);
        }
    }

    void TakeDamage(int amount) {
        Debug.Log("Taking Damage");

        currentHealth -= amount;
        healthSlider.value = currentHealth;
    }
}
