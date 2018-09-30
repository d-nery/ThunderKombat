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
    RobotController robotController;
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
        robotController = GetComponent<RobotController>();

    }
	
	// Update is called once per frame

    void ResetGame(bool IskeiroVictory, bool DarcVictory)
    {
        if (IskeiroVictory)
            IskeiroWins++;
        if (DarcVictory)
            DarcWins++;

        
        IskeiroHealth.currentHealth = 100;
        DarcHealth.currentHealth = 1000;
        GameTimer.finished = true;
        robotController.ResetTransform();



    }
	void Update () {


        if (IskeiroWins == 0 && DarcWins == 0) // Primeira vitoria de cada um
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth)
                {
                    ResetGame(true, false);
                    WinnerName.text = "Darc  K.O";
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    ResetGame(false, true);
                    WinnerName.text = "Iskeiro  K.O";
                }
                else
                {
                    ResetGame(false, false);
                    WinnerName.text = "Draw";
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0)
                {
                    ResetGame(false, true);
                    WinnerName.text = "Iskeiro  K.O";
                    audioExcellent.Play();
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    ResetGame(true, false);
                    WinnerName.text = "Darc  K.O";
                }
                else // Durante o jogo
                {
                    WinnerName.text = "";
                }
            }
        }

        else if (IskeiroWins == 1 && DarcWins == 0)
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth) //Game Finish
                {
                    ResetGame(true, false);
                    audioExcellent.Play();
                    WinnerName.text = "Iskeiro  Wins";
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    ResetGame(false, true);     
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  K.O";

                }
                else
                {
                    WinnerName.text = "Draw";
                    ResetGame(false, false);
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0) //Iskeiro Perde
                {
                    ResetGame(false, true);
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  K.O";
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    ResetGame(true, false);
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  Wins";
                }
                else // Não acabou
                {
                    WinnerName.text = "";
                }
            }
        }

        else if (IskeiroWins == 0 && DarcWins == 1) //Continuar Usar função depois
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth)
                {
                    GameTimer.finished = true;
                    IskeiroWins++;
                    WinnerName.text = "Darc  K.O";
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    GameTimer.finished = true;
                    DarcWins++;
                    WinnerName.text = "Darc  Wins";
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
                }
                else
                {
                    GameTimer.finished = true;
                    WinnerName.text = "Draw";
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
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
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    IskeiroWins++;
                    audioImpressive.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Darc  K.O";
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
                }
                else // Não acabou
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
                    GameTimer.finished = true;
                    WinnerName.text = "Iskeiro Wins";
                    GameTimer.finished = true;
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    DarcWins++;
                    GameTimer.finished = true;
                    WinnerName.text = "Darc  Wins";
                    GameTimer.finished = true;
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
                }
                else
                {
                    WinnerName.text = "Draw";
                    GameTimer.finished = true;
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
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
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    IskeiroWins++;
                    audioWellDone.Play();
                    GameTimer.finished = true;
                    WinnerName.text = "Iskeiro Wins";
                    IskeiroHealth.currentHealth = 100;
                    DarcHealth.currentHealth = 1000;
                    robotController.ResetTransform();
                }
                else // Não acabou
                {
                    WinnerName.text = "";
                }
            }
        }

    }
}
