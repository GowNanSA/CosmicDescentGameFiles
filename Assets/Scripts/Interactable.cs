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

    public UnityEvent onInteraction;

    void Start() {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

/*
    public void Update() {
        print(MinigameEnd.isCollected[id]);

        if(MinigameEnd.isCollected[id]) {
            //check the index of isCollected and hide the object if the id matches the index of isCollected
            if (id == 0) {
                gameObject.SetActive(false);
            } else if (id == 1) {
                gameObject.SetActive(false);
            } else if (id == 2) {
                gameObject.SetActive(false);
            }
        }
    }
    */

    public void Interact() {
        //load the wire puzzle 
        MinigameEnd.isCollected[id] = true; 
        SceneManager.LoadScene("WirePuzzle");
    }

    public void DisableOutline() {
        outline.enabled = false;
    }

    public void EnableOutline() {
        outline.enabled = true;
    }
}
