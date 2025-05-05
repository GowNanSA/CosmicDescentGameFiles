using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;


    void Update()
    {
        checkInteraction();
        if (Input.GetMouseButtonDown(0) && currentInteractable != null)
        {
            Debug.Log("Interacting with: " + currentInteractable.gameObject.name);
            currentInteractable.Interact();
        }
    }

    void checkInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach)) {
            if (hit.collider.tag == "Interactable") {

                Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                if(currentInteractable && newInteractable != currentInteractable) { // if we are looking at a new interactable
                    DisableCurrentInteractable();
                }
                if (newInteractable.enabled) {
                    SetNewCurrentInteractable(newInteractable);
                }
                else { // if interactable is not enabled
                    DisableCurrentInteractable();
                }
            } else { // if not interactable
                DisableCurrentInteractable();
            }
        }
        else { // if nothing is in reach
            DisableCurrentInteractable();
        }

    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
