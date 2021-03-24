using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardPen : MonoBehaviour
{
    public Whiteboard whiteboard;
    private RaycastHit touch;
    private bool lastTouch;
    private Quaternion lastAngle;

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
            if (!(touch.collider.tag == "Whiteboard"))
                return;

            this.whiteboard = touch.collider.GetComponent<Whiteboard>();

            this.whiteboard.SetColor(Color.blue);
            this.whiteboard.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
            this.whiteboard.ToggleTouch(true);

            if (!lastTouch)
            {
                lastTouch = true;
                lastAngle = transform.rotation;
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
