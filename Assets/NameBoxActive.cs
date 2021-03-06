using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameBoxActive : MonoBehaviour
{
    public TextboxManager manager;
    public void SetActive()
    {
        Debug.Log(manager);
        manager.textBox = this.GetComponent<TMP_InputField>();   

    }
}
