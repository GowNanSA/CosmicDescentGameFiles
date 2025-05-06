using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ColorTracker : MonoBehaviour
{
    private List<WireColor> UnpoweredWireColors = new List<WireColor> { WireColor.blue, WireColor.red, WireColor.green };
    private List<WireColor> PoweredWireColors = new List<WireColor> { WireColor.blue, WireColor.red, WireColor.green };

    public WireColor GetPoweredColor()
    {
        if (PoweredWireColors.Count == 0)
        {
            Debug.Log("No more colors left in the list.");
        }

        int index = Random.Range(0, PoweredWireColors.Count);
        WireColor color = PoweredWireColors[index];
        PoweredWireColors.RemoveAt(index);
        return color;
    }

    public WireColor GetUnPoweredColor()
    {
        if (UnpoweredWireColors.Count == 0)
        {
            Debug.Log("No more colors left in the list.");
        }

        int index = Random.Range(0, UnpoweredWireColors.Count);
        WireColor color = UnpoweredWireColors[index];
        UnpoweredWireColors.RemoveAt(index);
        return color;
    }
}
