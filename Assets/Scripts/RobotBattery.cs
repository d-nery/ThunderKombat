using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RobotBattery : MonoBehaviour
{
    public int startingCharge = 1000;
    private int currentCharge;
	public float dischargeRate = 1f;
	private int powerConsumption = 0;
	private float startTime;
    public Slider batterySlider;

    void Start () {
		startTime = Time.fixedTime;
        currentCharge = startingCharge;
    }

	void FixedUpdate() {
		if (Time.fixedTime - startTime >= dischargeRate * Time.timeScale) {
			Discharge(powerConsumption);
			powerConsumption = 1;
			startTime = Time.fixedTime;
		}
	}

	void Discharge(int amount) {
		currentCharge -= amount;
		batterySlider.value = currentCharge;
	}

	public void IncreasePowerConsumption(int amount) {
		powerConsumption += amount;
	}
}
