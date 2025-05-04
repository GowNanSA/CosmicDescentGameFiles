using System;
using UnityEngine;

public class PoweredWireBehavior : MonoBehaviour
{
    bool mouseDown = false;
    public PoweredWireStats powerWireS;
    LineRenderer line;
    public float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerWireS = gameObject.GetComponent<PoweredWireStats>();
        line = gameObject.GetComponentInParent<LineRenderer>();

        if(powerWireS.objectColor == WireColor.blue)
        {
            offset = 0.324148f;
        }
        else if(powerWireS.objectColor == WireColor.red)
        {
            offset = -2.4f;
        }
        else
        {
            offset = -5.4f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
        line.SetPosition(0, new Vector3(gameObject.transform.localPosition.x - 0.792598f, gameObject.transform.localPosition.y + offset, 5));
        line.SetPosition(1, new Vector3(gameObject.transform.localPosition.x - 1f, gameObject.transform.localPosition.y + offset, 5));
        //line.SetPosition(2, new Vector3(-7.009651f, 3.104148f, 5));
        //line.SetPosition(3, new Vector3(-7.390931f, 3.104148f, 5));
    }

    void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseOver()
    {
        powerWireS.movable = true;
    }

    private void OnMouseExit()
    {
        if(!powerWireS.moving)
        {
            powerWireS.movable = false;
        }
    }
    private void OnMouseUp()
    {
        mouseDown = false;
        if(!powerWireS.connected)
        {
            gameObject.transform.position = powerWireS.startPosition;
        }
        else
        {
            gameObject.transform.position = powerWireS.connectedPosition;
        }
    }

    void MoveWire()
    {
        if(mouseDown && powerWireS.movable)
        {
            powerWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, transform.position.z));
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.parent.transform.position.z);
        }
        else
        {
            powerWireS.moving = false;
        }
        
    }

}
