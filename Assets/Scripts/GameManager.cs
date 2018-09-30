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
    public bool GameFinished = false;

    RobotHealth IskeiroHealth;
    RobotHealth DarcHealth;
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


    void Start () {

        IskeiroHealth = Iskeiro.GetComponent<RobotHealth>();
        DarcHealth = darc.GetComponent<RobotHealth>();
        WinnerName = WinText.GetComponent<Text>();
        GameTimer = Canvas.GetComponent<Timer>();
        audioExcellent = GetComponent<AudioSource>();
        audioImpressive = GetComponent<AudioSource>();
        audioWellDone = GetComponent<AudioSource>();
        robotControllerIskeiro = Iskeiro.GetComponent<RobotController>();
        robotControllerDarc = darc.GetComponent<RobotController>();

       



    }
	
	// Update is called once per frame

    IEnumerator ResetGame(bool IskeiroVictory, bool DarcVictory)
    {
        if (IskeiroVictory)
            IskeiroWins++;
        if (DarcVictory)
            DarcWins++;

 
        IskeiroHealth.currentHealth = IskeiroHealth.startingHealth;
        DarcHealth.currentHealth = DarcHealth.startingHealth;


        IskeiroHealth.healthSlider.value = IskeiroHealth.startingHealth;
        DarcHealth.healthSlider.value = DarcHealth.startingHealth;

       yield return new WaitForSeconds(3);
       robotControllerDarc.ResetTransform();
       robotControllerIskeiro.ResetTransform();
        IskeiroHealth.currentHealth = IskeiroHealth.startingHealth;
        DarcHealth.currentHealth = DarcHealth.startingHealth;

        GameTimer.finished = false;
        GameTimer.startTime = Time.fixedTime / 3.0f;

        IskeiroHealth.healthSlider.value = IskeiroHealth.startingHealth;
        DarcHealth.healthSlider.value = DarcHealth.startingHealth;





    }
	void Update () {

        if (GameFinished == true)
        {
            return;
        }


        if (IskeiroWins == 0 && DarcWins == 0) // Primeira vitoria de cada um
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth)
                {
                    StartCoroutine(ResetGame(true, false));
                    WinnerName.text = "Darc  K.O";
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    StartCoroutine(ResetGame(false, true));
                    WinnerName.text = "Iskeiro  K.O";
                }
                else
                {
                    StartCoroutine(ResetGame(false, false));
                    WinnerName.text = "Draw";
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0)
                {
                    StartCoroutine(ResetGame(false, true));
                    WinnerName.text = "Iskeiro  K.O";
                    audioExcellent.Play();
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    StartCoroutine(ResetGame(true, false));
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
                    StartCoroutine(ResetGame(true, false));
                    audioExcellent.Play();
                    WinnerName.text = "Iskeiro  Wins";
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    StartCoroutine(ResetGame(false, true));
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  K.O";

                }
                else
                {
                    WinnerName.text = "Draw";
                    StartCoroutine(ResetGame(false, false));
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0) //Iskeiro Perde
                {
                    StartCoroutine(ResetGame(false, true));
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  K.O";
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    StartCoroutine(ResetGame(true, false));
                    audioImpressive.Play();
                    WinnerName.text = "Iskeiro  Wins";
                }
                else // Não acabou
                {
                    WinnerName.text = "";
                }
            }
        }

        else if (IskeiroWins == 0 && DarcWins == 1) //Continuar Usar função depois TO-DO
        {
            if (GameTimer.finished)
            {

                if (10 * IskeiroHealth.currentHealth > DarcHealth.currentHealth)
                {
                    StartCoroutine(ResetGame(true, false));
                    WinnerName.text = "Darc  K.O";

                    
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    StartCoroutine(ResetGame(false, true));
                    WinnerName.text = "Darc  Wins";
                    
                }
                else
                {
                    StartCoroutine(ResetGame(false, false));
                    WinnerName.text = "Draw";

                    
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0)
                {
                    StartCoroutine(ResetGame(false, true));
                    WinnerName.text = "Darc  Wins";
                    audioImpressive.Play();

                    
                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    StartCoroutine(ResetGame(true, false));
                    WinnerName.text = "Darc  K.O";
                    audioImpressive.Play();

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
                    StartCoroutine(ResetGame(true, false));
                    WinnerName.text = "Iskeiro Wins";
                    GameFinished = true;
       
                }
                else if (10 * IskeiroHealth.currentHealth < DarcHealth.currentHealth)
                {
                    StartCoroutine(ResetGame(false, true));
                    WinnerName.text = "Darc  Wins";
                    GameFinished = true;


                }
                else
                {
                    StartCoroutine(ResetGame(false, false));
                    WinnerName.text = "Draw";                                 
                }

            }
            else
            {
                if (IskeiroHealth.currentHealth <= 0)
                {
                    StartCoroutine(ResetGame(false, true));
                    WinnerName.text = "Darc  Wins";
                    audioWellDone.Play();
                    GameFinished = true;

                }
                else if (DarcHealth.currentHealth <= 0)
                {
                    StartCoroutine(ResetGame(true, false));
                    WinnerName.text = "Iskeiro  Wins";
                    audioWellDone.Play();
                    GameFinished = true;

                }
                else // Não acabou
                {
                    WinnerName.text = "";
                }
            }
        }

    }
}
