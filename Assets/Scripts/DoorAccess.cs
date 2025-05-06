using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DoorAccess : MonoBehaviour
{
    Outline outline;
    public GameObject door;

    public UnityEvent onInteraction;

    void Start() {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact() {
        if (MinigameEnd.minigamesLeft <= 0) {
            Destroy(door);
            onInteraction.Invoke();
        } else {
            Debug.Log("You need to complete all minigames first!");
        }
        
    }

    public void DisableOutline() {
        outline.enabled = false;
    }

    public void EnableOutline() {
        outline.enabled = true;
    }
}
