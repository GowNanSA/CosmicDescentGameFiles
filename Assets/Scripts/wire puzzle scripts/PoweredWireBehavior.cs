using System;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PoweredWireBehavior : MonoBehaviour
{
    bool mouseDown = false;
    private PoweredWireStats powerWireS;
    LineRenderer line;
    public float offset;
    public int position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerWireS = gameObject.GetComponent<PoweredWireStats>();
        line = gameObject.GetComponentInParent<LineRenderer>();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        UnityEngine.Sprite[] sprites = Resources.LoadAll<UnityEngine.Sprite>("Sprites/wire sprites");
        UnityEngine.Sprite loadedSprite = null;

        if (powerWireS.objectColor == WireColor.blue)
        {
            loadedSprite = sprites.FirstOrDefault(s => s.name == "wire sprites_0");
            line.material = Resources.Load<Material>("Sprites/blue");
        }
        else if (powerWireS.objectColor == WireColor.red)
        {
            loadedSprite = sprites.FirstOrDefault(s => s.name == "wire sprites_4");
            line.material = Resources.Load<Material>("Sprites/red");
        }
        else
        {
            loadedSprite = sprites.FirstOrDefault(s => s.name == "wire sprites_8");
            line.material = Resources.Load<Material>("Sprites/green");
        }

        if (loadedSprite == null)
        {
            Debug.LogError("Sprite failed to load. Make sure it's sliced and named correctly!");
        }
        else
        {
            //Debug.Log("Sprite loaded: " + loadedSprite.name);
            sr.sprite = loadedSprite;
        }

        if (position == 1)
        {
            offset = 0.324148f;
        }
        else if (position == 2)
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
