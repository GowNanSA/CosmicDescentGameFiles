using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Deselect any UI element on scene load
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OpenScene(int index) {
        SceneManager.LoadScene(index);
    }

    public void QuitGame() {
        Application.Quit();
    }
   
}
