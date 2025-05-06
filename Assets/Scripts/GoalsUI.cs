using UnityEngine;
using TMPro; 

public class GoalsUI : MonoBehaviour
{

    public TMP_Text text; // Reference to the TextMeshPro component
    public AudioSource audioSource; // Reference to the AudioSource component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
        
        //stop music
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Keycards Left: " + MinigameEnd.minigamesLeft.ToString();
    }
}
