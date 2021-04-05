using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPositioner : MonoBehaviour
{
    private Transform screen;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RearrangeScreens", .1f);
    }

    public void RearrangeScreens()
    {
        GameObject screenshareW = GameObject.FindGameObjectWithTag("WhiteboardObject");
        GameObject screenshareS = GameObject.FindGameObjectWithTag("Monitor");
        screen = screenshareW.transform;

        screenshareS.transform.GetChild(1).rotation = screen.rotation;
        screenshareS.transform.GetChild(1).localScale = screen.localScale;
        screenshareS.transform.GetChild(1).position = screen.position + (screen.transform.forward * (-0.1f));

        screenshareS.transform.GetChild(0).gameObject.SetActive(false);
    }
}
