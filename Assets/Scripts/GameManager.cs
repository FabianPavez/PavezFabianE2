using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float Reloj = 2f;

    public enum GameState
    {
        Gameplay,
        Wait,
        GameOver,
        RoundOver
    }
    public GameState CurrentGameState = GameState.Wait;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CurrentGameState = GameState.Wait;
    }

    void Update()
    {
        if (GameManager.instance.CurrentGameState == GameManager.GameState.Wait)
        {
            Reloj -= Time.deltaTime;
            if (Reloj <= 0)
            {
                Juego();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Juego();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            FinJuego();
        }
    }

    public void Esperar()
    {
        SetGameState(GameState.Wait);
    }

    public void Juego()
    {
        SetGameState(GameState.Gameplay);
    }

    public void FinJuego()
    {
        SetGameState(GameState.GameOver);
    }

    public void FinRonda()
    {
        SetGameState(GameState.RoundOver);
    }
    
    public void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.Gameplay)
        {

        }
        else if (newGameState == GameState.Wait)
        {

        }
        else if (newGameState == GameState.RoundOver)
        {

        }
        else if (newGameState == GameState.GameOver)
        {

        }

        this.CurrentGameState = newGameState;
    }
}