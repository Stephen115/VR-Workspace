using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToTextBox : MonoBehaviour
{
    public string activeTextBox;
    public string text;
    public string textbox;
    public void SendText() 
    {
        text = GameObject.Find("input").GetComponent<Text>().text;
        Debug.Log(text);
        Debug.Log(activeTextBox);
        textbox = activeTextBox;
        //GameObject.Find(activeTextBox).GetComponent<Text>().text = text;
    }
}
