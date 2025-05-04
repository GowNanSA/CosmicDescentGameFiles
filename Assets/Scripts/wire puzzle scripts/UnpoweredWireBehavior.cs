using UnityEngine;

public class UnpoweredWireBehavior : MonoBehaviour
{
    UnpoweredWireStats unpoweredWireS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unpoweredWireS = gameObject.GetComponent<UnpoweredWireStats>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageLight();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PoweredWireStats>())
        {
            PoweredWireStats poweredWireS = collision.GetComponent<PoweredWireStats>();
            if(poweredWireS.objectColor == unpoweredWireS.objectColor)
            {
                poweredWireS.connected = true;
                unpoweredWireS.connected = true;
                poweredWireS.connectedPosition = gameObject.transform.position;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PoweredWireStats>())
        {
            PoweredWireStats poweredWireS = collision.GetComponent<PoweredWireStats>();
            if (poweredWireS.objectColor == unpoweredWireS.objectColor)
            {
                poweredWireS.connected = false;
                unpoweredWireS.connected = false;
            }
        }
    }
    void ManageLight()
    {
        if (unpoweredWireS.connected)
        {
            unpoweredWireS.onLight.SetActive(true);
            unpoweredWireS.offLight.SetActive(false);
        }
        else
        {
            unpoweredWireS.onLight.SetActive(false);
            unpoweredWireS.offLight.SetActive(true);
        }
    }
}
