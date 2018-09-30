using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RobotHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
	public int bulletDamage = 10;
	public int activeWeaponDamage = 20;
	public int wedgeDamage = 15;
    public Slider healthSlider;

	private HingeJoint hjoint;

    void Start () {
        currentHealth = startingHealth;
    }

	public void OnCollisionEnter(Collision col) {
		print("Collision detected: " + col.gameObject.tag);
		if (col.gameObject.tag == "Bullet") {
			print("Collision of a Bullet.");
            TakeDamage(bulletDamage);

			hjoint = col.gameObject.GetComponent<HingeJoint>();
			if (hjoint.velocity > Mathf.Abs(500)) {
				print("Take damage from active weapon.");
				TakeDamage(activeWeaponDamage);
			}
		} else if (col.gameObject.tag == "Wedge") {
			print("Collision of a Wedge.");
			TakeDamage(wedgeDamage);
		}
	}

	public void OnTriggerEnter(Collider col) {
		print("Trigger detected: " + col.gameObject.tag);
		if (col.gameObject.tag == "Bullet") {
			print("Collision of a Bullet.");
			TakeDamage(bulletDamage);
		}
	}

	void TakeDamage(int amount) {
		currentHealth -= amount;
		healthSlider.value = currentHealth;
	}
}
