using UnityEngine;

public class UIAdjuster : MonoBehaviour
{
    public int offset;
    public int rightOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();

        // Step 1: Set anchors and pivot
        rt.anchorMin = new Vector2(1, 1);
        rt.anchorMax = new Vector2(1, 1);
        rt.pivot = new Vector2(1, 1);

        // Step 2: Reset position so it's visually placed at the top-right
        rt.anchoredPosition = new Vector2(-10 + rightOffset, -10 + offset); // 10 px from top-right
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
