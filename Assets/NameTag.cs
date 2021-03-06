using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameTag : MonoBehaviour
{
    public string username;
    // Start is called before the first frame update
    void Start()
    {
        username = DataStore.DS.username;

        GetComponent<TextMeshPro>().text = username;
    }
}
