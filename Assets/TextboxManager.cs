using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{
    public TMP_InputField textBox;
    public Text textInput;
    public void Update()
    {
        if (textBox != null)
        {
            textBox.text = textInput.text;
        }
    }

}
