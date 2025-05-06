using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum WireColor { blue, red, green };

public class PoweredWireStats : MonoBehaviour
{
    public bool movable = false;
    public bool moving = false;
    public Vector3 startPosition;
    
    public bool connected = false;
    public Vector3 connectedPosition;

    public ColorTracker colors;
    public WireColor objectColor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //colors = gameObject.GetComponent<ColorTracker>();
        objectColor = colors.GetPoweredColor();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
