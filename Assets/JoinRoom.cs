using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField roomField;
    public Button joinButton;
    public DataStore information;
    public string sceneName;

    public void AttemptJoin()
    {
        sceneName = "SampleScene";
        if (nameField.text.Length > 0 && roomField.text.Length > 0)
        {
            information.username = nameField.text;
            information.roomNumber = roomField.text;
            Debug.Log("YAY");
            SceneManager.LoadScene(sceneName);
        }
        else 
        {
            StartCoroutine(FailClick());
            Debug.Log(":(");
        }
    }
    IEnumerator FailClick()
    {
        var colors = GetComponent<Button>().colors;
        colors.selectedColor = Color.red;
        GetComponent<Button>().colors = colors;
        yield return new WaitForSeconds(1);
        colors.selectedColor = Color.gray;
        GetComponent<Button>().colors = colors;

    }
}
