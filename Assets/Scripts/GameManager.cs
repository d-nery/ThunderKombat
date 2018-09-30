using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public GameObject Iskeiro;
    public GameObject WinText;
    public GameObject darc;
    public GameObject Canvas;
    public int Round = 0;
    public bool GameFinished = false;

    private RobotHealth IskeiroHealth;
    private RobotBattery IskeiroBattery;
    private RobotHealth DarcHealth;
    private RobotBattery DarcBattery;
    RobotController robotControllerIskeiro;
    RobotController robotControllerDarc;
    Text WinnerName;
    Timer GameTimer;

    public int IskeiroWins = 0;
    public int DarcWins = 0;

    public AudioSource audioExcellent;
    public AudioSource audioImpressive;
    public AudioSource audioWellDone;
    private bool isPlaying = false;
    private float sec = 0;

    private bool resetting = false;


    void Start () {
        IskeiroHealth = Iskeiro.GetComponent<RobotHealth>();
        DarcHealth = darc.GetComponent<RobotHealth>();
        DarcBattery = darc.GetComponent<RobotBattery>();
        IskeiroBattery = Iskeiro.GetComponent<RobotBattery>();

        WinnerName = WinText.GetComponent<Text>();
        GameTimer = Canvas.GetComponent<Timer>();

        audioExcellent = GetComponent<AudioSource>();
        audioImpressive = GetComponent<AudioSource>();
        audioWellDone = GetComponent<AudioSource>();

        robotControllerIskeiro = Iskeiro.GetComponent<RobotController>();
        robotControllerDarc = darc.GetComponent<RobotController>();

        resetting = false;
    }

    void ResetGame(bool IskeiroVictory, bool DarcVictory) {
        resetting = true;

        if (Time.fixedTime - sec < 3f)
            return;

        if (IskeiroVictory)
            IskeiroWins++;
        if (DarcVictory)
            DarcWins++;


        robotControllerDarc.ResetPos();
        robotControllerIskeiro.ResetPos();

        IskeiroHealth.currentHealth = IskeiroHealth.startingHealth;
        DarcHealth.currentHealth = DarcHealth.startingHealth;
        IskeiroHealth.healthSlider.value = IskeiroHealth.startingHealth;
        DarcHealth.healthSlider.value = DarcHealth.startingHealth;

        IskeiroBattery.currentCharge = IskeiroBattery.startingCharge;
        DarcBattery.currentCharge = DarcBattery.startingCharge;
        IskeiroBattery.batterySlider.value = IskeiroBattery.startingCharge;
        DarcBattery.batterySlider.value = DarcBattery.startingCharge;

        GameTimer.finished = false;
        GameTimer.startTime = Time.fixedTime / 3.0f;

        resetting = false;
    }

    void Update () {
        if (GameFinished == true) {
            if (Input.GetAxis("P1A") > 0) {
                SceneManager.LoadScene(0);
            }
            return;
        }

        if (!resetting) {
            sec = Time.fixedTime;
        }

        if (IskeiroWins == 0 && DarcWins == 0) {
            if (GameTimer.finished) {
                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth) {
                    WinnerName.text = "Darc  K.O";
                    ResetGame(true, false);

                } else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth) {
                    WinnerName.text = "Iskeiro  K.O";
                    ResetGame(false, true);
                } else {
                    WinnerName.text = "Draw";
                    ResetGame(false, false);
                }
            } else {
                if (IskeiroHealth.currentHealth <= 0) {
                    WinnerName.text = "Iskeiro  K.O";
                    ResetGame(false, true);
                    audioExcellent.Play();
                } else if (DarcHealth.currentHealth <= 0) {
                    WinnerName.text = "Darc  K.O";
                    ResetGame(true, false);
                } else {
                    WinnerName.text = "";
                }
            }
        } else if (IskeiroWins == 1 && DarcWins == 0) {
            if (GameTimer.finished) {
                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth) {
                    GameFinished = true;
                    WinnerName.text = "Iskeiro  Wins";
                    audioExcellent.Play();
                    ResetGame(true, false);
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth) {
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  K.O";
                    ResetGame(false, true);
                } else {
                    WinnerName.text = "Draw";
                    ResetGame(false, false);
                }
            } else {
                if (IskeiroHealth.currentHealth <= 0) {
                    WinnerName.text = "Iskeiro  K.O";
                    audioImpressive.Play();
                    ResetGame(false, true);
                } else if (DarcHealth.currentHealth <= 0) {
                    GameFinished = true;
                    WinnerName.text = "Iskeiro  Wins";
                    audioImpressive.Play();
                    ResetGame(true, false);
                } else {
                    WinnerName.text = "";
                }
            }
        } else if (IskeiroWins == 0 && DarcWins == 1) {
            if (GameTimer.finished) {
                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth) {
                    WinnerName.text = "Darc  K.O";
                    ResetGame(true, false);
                } else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth) {
                    GameFinished = true;
                    WinnerName.text = "Darc  Wins";
                    ResetGame(false, true);
                } else {
                    WinnerName.text = "Draw";
                    ResetGame(false, false);
                }
            } else {
                if (IskeiroHealth.currentHealth <= 0) {
                    GameFinished = true;
                    WinnerName.text = "Darc  Wins";
                    audioImpressive.Play();
                    ResetGame(false, true);
                } else if (DarcHealth.currentHealth <= 0) {
                    WinnerName.text = "Darc  K.O";
                    audioImpressive.Play();
                    ResetGame(true, false);
                } else {
                    WinnerName.text = "";
                }
            }
        } else if (IskeiroWins == 1 && DarcWins == 1) {
            if (GameTimer.finished) {
                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth) {
                    WinnerName.text = "Iskeiro Wins";
                    GameFinished = true;
                    ResetGame(true, false);
                } else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth) {
                    GameFinished = true;
                    WinnerName.text = "Darc  Wins";
                    ResetGame(false, true);
                } else {
                    WinnerName.text = "Draw";
                    ResetGame(false, false);
                }
            } else {
                if (IskeiroHealth.currentHealth <= 0) {
                    GameFinished = true;
                    WinnerName.text = "Darc  Wins";
                    audioWellDone.Play();
                    ResetGame(false, true);
                } else if (DarcHealth.currentHealth <= 0) {
                    WinnerName.text = "Iskeiro  Wins";
                    audioWellDone.Play();
                    GameFinished = true;
                    ResetGame(true, false);
                } else {
                    WinnerName.text = "";
                }
            }
        }
    }
}
