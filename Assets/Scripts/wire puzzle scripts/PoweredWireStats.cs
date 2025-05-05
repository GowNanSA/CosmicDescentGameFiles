using UnityEngine;
using UnityEngine.SceneManagement;

public enum WireColor { blue, red, green };

public class PoweredWireStats : MonoBehaviour
{
    public bool movable = false;
    public bool moving = false;
    public Vector3 startPosition;
    public WireColor objectColor;
    public bool connected = false;
    public Vector3 connectedPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
