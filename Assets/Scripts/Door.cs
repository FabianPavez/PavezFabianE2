using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Door : MonoBehaviour
{
    TextMeshPro text;

    public Color[] ColorBank;
    public bool sprite;

    public string Letter;

    
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Ejemplo para mostrar como se escribe texto
        SetDoorText("A");
        SetDoorColor();
    }

    void SetDoorColor()
    {
        int Num = Random.Range(0, ColorBank.Length);
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        s.color = ColorBank[Num];
    }

    private void SetDoorText(string textToDisplay)
    {

        text.SetText(textToDisplay);
    }


    //private void SetDoorText(int stringLength = 10)
    //{
    //    int _stringLength = stringLength - 1;
    //    string randomString = "";
    //    string[] characters = new string[] { "a", "b", "c", "d", "e" };
    //    for (int i = 0; i <= _stringLength; i++)
    //    {
    //        randomString = randomString + characters[Random.Range(0, characters.Length)];
    //    }
    //    print(randomString);
    //}


    //string letra = Random.Range(0, Letras.Length);
}
