using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public int id = 0;
    public string message;

    public bool isDoor;
    public bool isCaptain;

    public UnityEvent onInteraction;

    void Start() {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact() {
        //load the wire puzzle
        if(!isDoor && !isCaptain) {
            MinigameEnd.isCollected[id] = true; 
            SceneManager.LoadScene("WirePuzzle");
        } else if(isDoor) {
            if(MinigameEnd.minigamesLeft <= 0) {
                Destroy(this.gameObject);
            }
        } else if(isCaptain) {
            MinigameEnd.minigamesLeft = 3;
            MinigameEnd.isCollected = new bool [] {false, false, false};
            //unlock cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Application.Quit();
        }
        
    }

    public void DisableOutline() {
        outline.enabled = false;
    }

    public void EnableOutline() {
        outline.enabled = true;
    }
}
