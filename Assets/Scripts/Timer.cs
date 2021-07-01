using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Reloj = 150f;
    public Text ContadorText;
    public int TiempoToText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CurrentGameState == GameManager.GameState.Gameplay)
        {
            Reloj -= Time.deltaTime;
            TiempoToText = (int)Reloj;
            ContadorText.text = TiempoToText.ToString();
            if (Reloj <= 0)
            {
                GameManager.instance.SetGameState(GameManager.GameState.GameOver);
            }
        }

    }
}
