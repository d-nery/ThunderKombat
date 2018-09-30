using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RobotBattery : MonoBehaviour
{
    public int startingCharge = 1000;
    private int currentCharge;
	public float dischargeRate = 1f;
	private int powerConsumption = 0;
	private float startTime1;
	private float startTime2;
    public Slider batterySlider;

    void Start () {
		startTime1 = Time.fixedTime;
		startTime2 = Time.fixedTime;
        currentCharge = startingCharge;
    }

	void FixedUpdate() {
		if (Time.fixedTime - startTime1 >= dischargeRate * Time.timeScale) {
			Discharge(powerConsumption);
			powerConsumption = 1;
			startTime1 = Time.fixedTime;
		}
	}

	void Discharge(int amount) {
		currentCharge -= amount;
		batterySlider.value = currentCharge;
	}

	public void IncreasePowerConsumption(int amount) {
		if (Time.fixedTime - startTime2 >= dischargeRate * Time.timeScale / 10) {
			powerConsumption += amount;
			startTime2 = Time.fixedTime;
		}
	}
}
