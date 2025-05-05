using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public string message;

    public UnityEvent onInteraction;

    void Start() {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact() {
        //load the wire puzzle 
        SceneManager.LoadScene("WirePuzzle");
    }

    public void DisableOutline() {
        outline.enabled = false;
    }

    public void EnableOutline() {
        outline.enabled = true;
    }
}
