using System.Collections;
using System.Linq;
using UnityEngine;

public class FindPoweredColor : MonoBehaviour
{
    private PoweredWireStats powerWireS;
    void Start()
    {

    }

    private void Update()
    {
        powerWireS = transform.parent.GetComponentInChildren<PoweredWireStats>();
        //Debug.Log(powerWireS.objectColor);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        UnityEngine.Sprite[] sprites = Resources.LoadAll<UnityEngine.Sprite>("Sprites/wire sprites");
        UnityEngine.Sprite loadedSprite = null;

        if (powerWireS.objectColor == WireColor.blue)
        {
            loadedSprite = sprites.FirstOrDefault(s => s.name == "wire sprites_1");
        }
        else if (powerWireS.objectColor == WireColor.red)
        {
            loadedSprite = sprites.FirstOrDefault(s => s.name == "wire sprites_5");
        }
        else
        {
            loadedSprite = sprites.FirstOrDefault(s => s.name == "wire sprites_9");
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
    }
}
