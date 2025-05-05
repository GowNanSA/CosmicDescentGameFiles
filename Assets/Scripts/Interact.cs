using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OutlineSelection : MonoBehaviour
{
    // if the current object is clicked on, take the player to the next scene
    public void OnMouseDown()
    {
        // Check if the object is clicked
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Load the next scene
            SceneManager.LoadScene("WirePuzzle"); // Replace with your scene name
        }
    }
}
