using UnityEngine;
using TMPro;
using DefaultNamespace;

public class ButtonPressInteractable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    /*
    bool buttonPressed; 

    [SerializeField] float pressDistance = 0.5f;
    TextMeshProUGUI interactionText; 
    Camera playerCamera;
    public GameObject currentTargetedInteractable;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentInteractable();
        UpdateInteractionText();
        CheckForInteractionInput(); 

        // if the button gets pressed, delete the door object that is blocking the player to let them through 
        if (buttonPressed) {
            Destroy(currentTargetedInteractable); // destroy the door object 
            buttonPressed = false; // reset the button pressed state 
        }

    }

    void UpdateCurrentInteractable() {
        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        Physics.Raycast(ray, out var hit, pressDistance);

        // give the text when hit 
        currentTargetedInteractable = hit.collider?.GetComponent<Interactable>(); 

    }

    void UpdateInteractionText() {
        if(currentTargetedInteractable == null){
            interactionText.text = string.Empty;
            return; 
        }
    }

    void CheckForInteractionInput() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            currentTargetedInteractable.Interact();
            buttonPressed = true; // set the button pressed state to true
        }
    }
    */
}