using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RobotBattery : MonoBehaviour
{
    public int startingCharge = 1000;
    public int currentCharge;
    public float dischargeRate = 1f;
    private int powerConsumption = 0;
    public Slider batterySlider;

    public int baseConsumption = 1;
    public int driveConsumption = 1;
    public int bulletConsumption = 1;
    public int weaponConsumption = 1;

    private bool driving = false;
    private bool shooting = false;
    private bool weaponOn = false;

    void Start () {
        currentCharge = startingCharge;
        InvokeRepeating("Discharge", 0, dischargeRate);
    }

    void Discharge() {
        if (Empty())
            return;

        int amount = 0;
        amount += baseConsumption;
        amount += driving ? driveConsumption : 0;
        amount += shooting ? bulletConsumption : 0;
        amount += weaponOn ? weaponConsumption : 0;

        currentCharge -= amount;
        batterySlider.value = currentCharge;
    }

    public void Shooting(bool isShooting) {
        shooting = isShooting;
    }

    public void Driving(bool isDriving) {
        driving = isDriving;
    }

    public void WeaponOn(bool isWeaponOn) {
        weaponOn = isWeaponOn;
    }

    public bool Empty() {
        return (currentCharge <= 0);
    }
}
