using UnityEngine;

public class UnpoweredWireStats : MonoBehaviour
{
    public bool connected = false;
    public WireColor objectColor;
    public GameObject onLight;
    public GameObject offLight;
    public ColorTracker colors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //colors = gameObject.GetComponent<ColorTracker>();
        objectColor = colors.GetUnPoweredColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
