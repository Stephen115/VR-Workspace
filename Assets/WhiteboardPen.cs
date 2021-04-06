using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardPen : MonoBehaviour
{
    public Whiteboard whiteboard;
    private RaycastHit touch;
    private bool lastTouch;
    private Quaternion lastAngle;
    public int penColor;

    // Start is called before the first frame update
    void Start()
    {
        this.whiteboard = GameObject.Find("Whiteboard").GetComponent<Whiteboard>();
    }

    // Update is called once per frame
    void Update()
    {
        float tipHeight = transform.Find("Tip").transform.localScale.y;
        Vector3 tip = transform.Find("Tip").transform.position;

        if (lastTouch)
        {
            tipHeight *= 1.1f;
        }

        if (Physics.Raycast(tip, transform.up, out touch, tipHeight))
        {
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA " + touch.transform.name);
            if (!(touch.collider.tag == "WhiteboardObject"))
                return;

            this.whiteboard = touch.collider.GetComponent<Whiteboard>();
            if (penColor == 0) 
            {
                this.whiteboard.SetColor(Color.blue);
            } else if (penColor == 1)
            {
                this.whiteboard.SetColor(Color.green);
            } else if (penColor == 2) 
            {
                this.whiteboard.SetColor(Color.red);
            } else if (penColor == 3)
            {
                this.whiteboard.SetColor(Color.black);
            } else if (penColor == 4)
            {
                this.whiteboard.SetColor(Color.white);
            } else if (penColor == 5)
            {
                this.whiteboard.SetColor(Color.yellow);
            } else if (penColor == 6)
            {
                this.whiteboard.SetColor(Color.magenta);
            } else if (penColor == 7)
            {
                this.whiteboard.SetColor(Color.cyan);
            } else if (penColor == 8)
            {
                this.whiteboard.SetColor(Color.clear);
            }

            this.whiteboard.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
            this.whiteboard.ToggleTouch(true);

            if (!lastTouch)
            {
                lastTouch = true;
                //lastAngle = transform.rotation;
            }
        }
        else 
        {
            lastTouch = false;
            this.whiteboard.ToggleTouch(false);
        }

        if (lastTouch) 
        {
            transform.rotation = lastAngle;
        }
    }
}
