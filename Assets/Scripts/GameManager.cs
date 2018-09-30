using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public GameObject Iskeiro;
    public GameObject WinText;
    public GameObject darc;
    public GameObject Canvas;
    public int Round = 0;

    RobotHealth IskeiroHealth;
    RobotHealth DarcHealth;
    Text WinnerName;
    Timer GameTimer;
    public int IskeiroWins = 0;
    public int DarcWins = 0;

    public AudioSource audioExcellent;
    public AudioSource audioImpressive;
    public AudioSource audioWellDone;
    private bool isPlaying = false;


    void Start () {

        IskeiroHealth = Iskeiro.GetComponent<RobotHealth>();
        DarcHealth = darc.GetComponent<RobotHealth>();
        WinnerName = WinText.GetComponent<Text>();
        GameTimer = Canvas.GetComponent<Timer>();
        audioExcellent = GetComponent<AudioSource>();
        audioImpressive = GetComponent<AudioSource>();
        audioWellDone = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {


        if (IskeiroWins == 0 && DarcWins == 0) // Primeira vitoria de cada um
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth)
                {
                    IskeiroWins++;
                    WinnerName.text = "Darc  K.O";
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    DarcWins++;
                    WinnerName.text = "Iskeiro  K.O";
                }
                else
                {
                    WinnerName.text = "Draw";
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0)
                {
                    DarcWins++;
                    audioExcellent.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Iskeiro  K.O";
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    IskeiroWins++;
                    audioExcellent.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Darc  K.O";
                }
                else
                {
                    WinnerName.text = "";
                }
            }
        }

        else if (IskeiroWins == 1 && DarcWins == 0)
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth)
                {
                    IskeiroWins++;
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  Wins";
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    DarcWins++;
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  K.O";
                }
                else
                {
                    WinnerName.text = "Draw";
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0)
                {
                    DarcWins++;
                    GameTimer.finished = true;
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  K.O";
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    IskeiroWins++;
                    audioImpressive.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Iskeiro  Wins";
                }
                else
                {
                    WinnerName.text = "";
                }
            }
        }

        else if (IskeiroWins == 0 && DarcWins == 1)
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth)
                {
                    IskeiroWins++;
                    WinnerName.text = "Darc  K.O";
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    DarcWins++;
                    WinnerName.text = "Darc  Wins";
                }
                else
                {
                    WinnerName.text = "Draw";
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0)
                {
                    DarcWins++;
                    audioImpressive.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Darc  Wins";
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    IskeiroWins++;
                    audioImpressive.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Darc  K.O";
                }
                else
                {
                    WinnerName.text = "";
                }
            }
        }

        else if (IskeiroWins == 1 && DarcWins == 1)
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth)
                {
                    IskeiroWins++;
                    WinnerName.text = "Iskeiro Wins";
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    DarcWins++;
                    WinnerName.text = "Darc  Wins";
                }
                else
                {
                    WinnerName.text = "Draw";
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0)
                {
                    DarcWins++;
                    audioWellDone.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Darc  Wins";
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    IskeiroWins++;
                    audioWellDone.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Iskeiro Wins";
                }
                else
                {
                    WinnerName.text = "";
                }
            }
        }

    }
}
