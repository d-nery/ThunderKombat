using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RobotReset : MonoBehaviour
{
    public int startingReset = 0;
    private int currentReset;

	public float reduceRate = 0.2f;
    public int jumpAmount = 190;
	public int baseReduce = 1;

	private bool pressing;

	public Slider resetSlider;

    void Start () {
        currentReset = startingReset;
    }

    void Update() {
		if (currentReset > 0) {
			currentReset -= baseReduce;
		}
		if (pressing) {
			currentReset += jumpAmount;
			pressing = false;
		}
		resetSlider.value = currentReset;
    }

	public void Pressing(bool isPressing) {
		pressing = isPressing;
	}
    public bool Full() {
        return currentReset >= 1000;
    }

	public void Reset() {
		currentReset = 0;
	}
}
