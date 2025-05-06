using System.Linq;
using UnityEngine;

public class FindUnpoweredColor : MonoBehaviour
{
    private UnpoweredWireStats unpoweredWireS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        unpoweredWireS = transform.parent.GetComponentInChildren<UnpoweredWireStats>();
        //Debug.Log(powerWireS.objectColor);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        UnityEngine.Sprite[] sprites = Resources.LoadAll<UnityEngine.Sprite>("Sprites/wire sprites");
        UnityEngine.Sprite loadedSprite = null;

        if (unpoweredWireS.objectColor == WireColor.blue)
        {
            loadedSprite = sprites.FirstOrDefault(s => s.name == "wire sprites_1");
        }
        else if (unpoweredWireS.objectColor == WireColor.red)
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
