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
    public AudioSource wedgeSound;
    public AudioSource weaponSound;
    public AudioSource fireSound;
    public Slider healthSlider;

    void Start () {
        currentHealth = startingHealth;
        wedgeSound = GetComponent<AudioSource>();
        weaponSound = GetComponent<AudioSource>();
        fireSound = GetComponent<AudioSource>();
    }

	public void OnCollisionEnter(Collision col) {
		print("Collision detected: " + col.gameObject.tag);
		if (col.gameObject.tag == "Bullet") {
			print("Collision of a Bullet.");
            fireSound.Play();
            TakeDamage(10);
		} else if (col.gameObject.tag == "ActiveWeapon") {
			/* TODO: Differ if the weapon is spinning */
			print("Collision of an Active Weapon.");
            weaponSound.Play();
            TakeDamage(20);
			healthSlider.value = currentHealth;
		} else if (col.gameObject.tag == "Wedge") {
			print("Collision of a Wedge.");
			TakeDamage(15);
			healthSlider.value = currentHealth;
            wedgeSound.Play();
		}
	}

	public void OnTriggerEnter(Collider col) {
		print("Trigger detected: " + col.gameObject.tag);
		if (col.gameObject.tag == "Bullet") {
			print("Collision of a Bullet.");
			TakeDamage(10);
		}
	}

	void TakeDamage(int amount) {
		currentHealth -= amount;
		healthSlider.value = currentHealth;
	}
}
